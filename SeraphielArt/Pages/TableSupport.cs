using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using System.Data;
using static SeraphielArt.Pages.Character.CharacterData;

namespace SeraphielArt.Pages;

public static class TableSupport
{
    /// <summary>
    /// Row type for price tables
    /// </summary>
    public enum PriceRowType
    {
        BaseComm,
        SingleExtension,
        SingleSelectable,
        MultiExtension,
        MultiSelectable
    }

    /// <summary>
    /// Convert a string into a name element supported in js
    /// </summary>
    /// <param name="name">Name to convert</param>
    /// <returns></returns>
    private static string GetNameJs(string name) => name.ToLower().Replace(" ", "_").Replace("-", "_");

    public static DataTable NewTable()
    {
        DataTable dt = new();
        dt.Columns.AddRange([new("RowType")]);
        return dt;
    }

    /// <summary>
    /// Create a new standart row for price tables
    /// </summary>
    /// <param name="table">Table for which to create a row</param>
    /// <param name="rowType">Type of the row to create</param>
    /// <param name="elements">Elements to include in the row, can be varied in number</param>
    /// <returns></returns>
    public static DataRow NewRow(this DataTable table, PriceRowType rowType, params object[] elements)
    {
        DataRow row = table.NewRow();
        row[0] = (int)rowType;
        for (int i = 1; i <= elements.Length && i < table.Columns.Count; i++)
        {
            row[i] = elements[i - 1];
        }
        return row;
    }

    /// <summary>
    /// Obtain the HTML code for a price table
    /// </summary>
    /// <param name="data">Datatable to use, create with <see cref="NewTable"/> and fill with <see cref="NewRow(DataTable, PriceRowType, object[])"/></param>
    /// <returns></returns>
    public static IHtmlContent GetPriceTable(DataTable data)
    {
        if (data.Columns.Count == 0)
        {
            TagBuilder pTag = new("p");
            pTag.InnerHtml.Append("No data available to display.");
            return pTag;
        }

        TagBuilder table = new("table");
        table.AddCssClass("table table-striped");

        TagBuilder thead = new("thead");
        TagBuilder headerRow = new("tr");
        for (int i = 1; i < data.Columns.Count; i++)
        {
            DataColumn column = data.Columns[i];
            TagBuilder th = new("th");
            th.AddCssClass("text-center");
            th.InnerHtml.Append(column.ColumnName);
            headerRow.InnerHtml.AppendHtml(th);
        }
        thead.InnerHtml.AppendHtml(headerRow);
        table.InnerHtml.AppendHtml(thead);


        TagBuilder tbody = new("tbody");
        foreach (DataRow row in data.Rows)
        {
            object? item;
            int nullElements = row.ItemArray.Count(x => x == DBNull.Value);
            
            TagBuilder td;
            TagBuilder tr = new("tr");
            switch (Convert.ToInt32(row.ItemArray[0]))
            {
                case (int)PriceRowType.BaseComm:
                    for (int i = 1; i < row.ItemArray.Length - nullElements; i++)
                    {
                        item = row.ItemArray[i];
                        td = new("td");
                        td.AddCssClass("text-center");
                        td.InnerHtml.Append(item?.ToString() ?? "");
                        tr.InnerHtml.AppendHtml(td);
                    }
                    break;

                case (int)PriceRowType.SingleExtension:
                case (int)PriceRowType.SingleSelectable:
                    item = row.ItemArray[1];
                    td = new("td");
                    td.AddCssClass("text-center");
                    td.InnerHtml.Append(item?.ToString() ?? "");
                    tr.InnerHtml.AppendHtml(td);

                    item = row.ItemArray[2];
                    td = new("td");
                    td.AddCssClass("text-center");
                    td.Attributes.Add("colspan", (row.ItemArray.Length - 2).ToString());
                    td.InnerHtml.Append(item?.ToString() ?? "");
                    tr.InnerHtml.AppendHtml(td);
                    break;


                case (int)PriceRowType.MultiExtension:
                case (int)PriceRowType.MultiSelectable:
                    goto case (int)PriceRowType.BaseComm;

            }

            tbody.InnerHtml.AppendHtml(tr);
        }
        table.InnerHtml.AppendHtml(tbody);


        return table;
    }

    /// <summary>
    /// Obtain the HTML code for the price preview of a price table
    /// </summary>
    /// <param name="data">Datatable to use, create with <see cref="NewTable"/> and fill with <see cref="NewRow(DataTable, PriceRowType, object[])"/></param>
    /// <returns></returns>
    public static IHtmlContent GetPricePreviewTable(DataTable data)
    {
        if (data.Columns.Count == 0)
        {
            TagBuilder pTag = new("p");
            pTag.InnerHtml.Append("No data available to display.");
            return pTag;
        }

        string name = GetNameJs(data.TableName);

        TagBuilder element = new("div");
        element.AddCssClass("row");
        element.Attributes.Add("id", $"{name}-row");

        for (int i = 0; i < data.Rows.Count; i++)
        {
            DataRow row = data.Rows[i];

            TagBuilder legend = new("legend");
            legend.AddCssClass("col-form-label col-sm-4 pt-0");
            legend.InnerHtml.Append($"{row.ItemArray[1]}");

            TagBuilder fieldset = new("fieldset");
            fieldset.AddCssClass("row mb-3");
            fieldset.InnerHtml.AppendHtml(legend);

            TagBuilder divCol = new("div");
            divCol.AddCssClass("col-sm-8");

            TagBuilder innerDiv;
            TagBuilder radioButton;
            TagBuilder radioLabel;
            TagBuilder divFormCheck;
            switch (Convert.ToInt32(row[0]))
            {
                case (int)PriceRowType.BaseComm:
                    for (int j = 2; j < data.Columns.Count; j++)
                    {
                        radioButton = new("input");
                        radioLabel = new("label");
                        divFormCheck = new("div");

                        radioButton.AddCssClass("form-check-input");
                        radioButton.Attributes.Add("type", "radio");
                        radioButton.Attributes.Add("name", $"{name}-radio-{i}");
                        radioButton.Attributes.Add("id", $"{name}-radio-{i}{j}");
                        radioButton.Attributes.Add("value", $"{row.ItemArray[j]?.ToString()?.Replace("$", "") ?? ""}");
                        radioButton.Attributes.Add("s-price", $"{row.ItemArray[j]?.ToString()?.Replace("$", "") ?? ""}");
                        if (j == 2)
                        {
                            radioButton.Attributes.Add("checked", "");
                        }

                        radioLabel.AddCssClass("form-check-label");
                        radioLabel.Attributes.Add("for", $"{name}-radio-{i}{j}");
                        radioLabel.InnerHtml.Append($"{data.Columns[j]} ({row.ItemArray[j]})");

                        divFormCheck.AddCssClass("form-check");
                        divFormCheck.InnerHtml.AppendHtml(radioButton);
                        divFormCheck.InnerHtml.AppendHtml(radioLabel);

                        divCol.InnerHtml.AppendHtml(divFormCheck);
                    }
                    fieldset.InnerHtml.AppendHtml(divCol);
                    element.InnerHtml.AppendHtml(fieldset);
                    break;

                case (int)PriceRowType.SingleExtension:
                    radioButton = new("input");
                    radioLabel = new("label");
                    divFormCheck = new("div");

                    radioButton.AddCssClass("form-check-input");
                    radioButton.Attributes.Add("type", "radio");
                    radioButton.Attributes.Add("name", $"{name}-radio-{i}");
                    radioButton.Attributes.Add("id", $"{name}-radio-{i}{2}");
                    radioButton.Attributes.Add("value", $"{row.ItemArray[2]?.ToString()?.Replace("$", "") ?? ""}");
                    radioButton.Attributes.Add("s-price", $"{row.ItemArray[2]?.ToString()?.Replace("$", "") ?? ""}");

                    radioLabel.AddCssClass("form-check-label");
                    radioLabel.Attributes.Add("for", $"{name}-radio-{i}{2}");

                    radioLabel.InnerHtml.Append($"{row.ItemArray[2]}");
                    radioButton.Attributes.Remove("type");
                    radioButton.Attributes.Add("type", "checkbox");

                    divFormCheck.AddCssClass("form-check");
                    divFormCheck.InnerHtml.AppendHtml(radioButton);
                    divFormCheck.InnerHtml.AppendHtml(radioLabel);

                    divCol.InnerHtml.AppendHtml(divFormCheck);
                    fieldset.InnerHtml.AppendHtml(divCol);
                    element.InnerHtml.AppendHtml(fieldset);
                    break;

                case (int)PriceRowType.SingleSelectable:
                    innerDiv = new("div");

                    radioButton = new("input");
                    divFormCheck = new("div");

                    radioButton.AddCssClass("form-control");
                    radioButton.Attributes.Add("type", "number");
                    radioButton.Attributes.Add("name", $"{name}-radio-{i}");
                    radioButton.Attributes.Add("id", $"{name}-radio-{i}{2}");
                    radioButton.Attributes.Add("value", $"0");
                    radioButton.Attributes.Add("min", $"0");
                    radioButton.Attributes.Add("s-price", $"{row.ItemArray[2]?.ToString()?.Replace("$", "") ?? ""}");

                    innerDiv.AddCssClass("col-sm-12");
                    innerDiv.InnerHtml.AppendHtml(radioButton);

                    divFormCheck.AddCssClass("row mb-2");
                    divFormCheck.InnerHtml.AppendHtml(innerDiv);

                    divCol.InnerHtml.AppendHtml(divFormCheck);
                    fieldset.InnerHtml.AppendHtml(divCol);
                    element.InnerHtml.AppendHtml(fieldset);
                    break;

                case (int)PriceRowType.MultiExtension:
                    radioButton = new("input");
                    radioLabel = new("label");
                    divFormCheck = new("div");

                    radioButton.AddCssClass("form-check-input");
                    radioButton.Attributes.Add("type", "radio");
                    radioButton.Attributes.Add("name", $"{name}-radio-{i}");
                    radioButton.Attributes.Add("id", $"{name}-radio-{i}1");
                    radioButton.Attributes.Add("value", "0");
                    radioButton.Attributes.Add("s-price", "0");
                    radioButton.Attributes.Add("checked", "");

                    radioLabel.AddCssClass("form-check-label");
                    radioLabel.Attributes.Add("for", $"{name}-radio-{i}1");
                    radioLabel.InnerHtml.Append($"None (0$)");

                    divFormCheck.AddCssClass("form-check");
                    divFormCheck.InnerHtml.AppendHtml(radioButton);
                    divFormCheck.InnerHtml.AppendHtml(radioLabel);

                    divCol.InnerHtml.AppendHtml(divFormCheck);

                    for (int j = 2; j < data.Columns.Count; j++)
                    {
                        radioButton = new("input");
                        radioLabel = new("label");
                        divFormCheck = new("div");

                        radioButton.AddCssClass("form-check-input");
                        radioButton.Attributes.Add("type", "radio");
                        radioButton.Attributes.Add("name", $"{name}-radio-{i}");
                        radioButton.Attributes.Add("id", $"{name}-radio-{i}{j}");
                        radioButton.Attributes.Add("value", $"{row.ItemArray[j]?.ToString()?.Replace("$", "") ?? ""}");
                        radioButton.Attributes.Add("s-price", $"{row.ItemArray[j]?.ToString()?.Replace("$", "") ?? ""}");

                        radioLabel.AddCssClass("form-check-label");
                        radioLabel.Attributes.Add("for", $"{name}-radio-{i}{j}");
                        radioLabel.InnerHtml.Append($"{data.Columns[j]} ({row.ItemArray[j]})");

                        divFormCheck.AddCssClass("form-check");
                        divFormCheck.InnerHtml.AppendHtml(radioButton);
                        divFormCheck.InnerHtml.AppendHtml(radioLabel);

                        divCol.InnerHtml.AppendHtml(divFormCheck);
                    }
                    fieldset.InnerHtml.AppendHtml(divCol);
                    element.InnerHtml.AppendHtml(fieldset);
                    break;

                case (int)PriceRowType.MultiSelectable:
                    for (int j = 2; j < data.Columns.Count; j++)
                    {
                        innerDiv = new("div");

                        radioButton = new("input");
                        radioLabel = new("label");
                        divFormCheck = new("div");

                        radioButton.AddCssClass("form-control");
                        radioButton.Attributes.Add("type", "number");
                        radioButton.Attributes.Add("name", $"{name}-radio-{i}");
                        radioButton.Attributes.Add("id", $"{name}-radio-{i}{j}");
                        radioButton.Attributes.Add("value", $"0");
                        radioButton.Attributes.Add("min", $"0");
                        radioButton.Attributes.Add("s-price", $"{row.ItemArray[j]?.ToString()?.Replace("$", "") ?? ""}");

                        radioLabel.AddCssClass("col-form-label col-sm-4");
                        radioLabel.Attributes.Add("for", $"{name}-radio-{i}{j}");
                        radioLabel.InnerHtml.Append($"{data.Columns[j]} ({row.ItemArray[j]})");

                        innerDiv.AddCssClass("col-sm-8");
                        innerDiv.InnerHtml.AppendHtml(radioButton);

                        divFormCheck.AddCssClass("row mb-2");
                        divFormCheck.InnerHtml.AppendHtml(radioLabel);
                        divFormCheck.InnerHtml.AppendHtml(innerDiv);

                        divCol.InnerHtml.AppendHtml(divFormCheck);
                    }
                    fieldset.InnerHtml.AppendHtml(divCol);
                    element.InnerHtml.AppendHtml(fieldset);
                    break;
            }
        }

        TagBuilder javascript = new("script");
        string script = $@"
document.addEventListener(""DOMContentLoaded"", function () {{
    // --------------------------------------------------------------
    // URI params
    // --------------------------------------------------------------
    const urlInputs = document.querySelectorAll('#{name}-row input');
    const urlParams = new URLSearchParams(window.location.search);
    const urlConfig = urlParams.get('config');

    if (urlConfig) {{
        try {{
            // Decode the Base64-encoded configuration string
            const decodedConfig = atob(urlConfig);

            // Parse the configuration string into key-value pairs
            const pairs = decodedConfig.split(',').filter(Boolean); // Remove empty strings from trailing commas
            
            if (pairs[0] == ""{name}"") {{
                pairs.shift();
                pairs.forEach(pair => {{
                    const [index, value] = pair.split('-');

                    // Apply values to the corresponding inputs
                    const input = urlInputs[parseInt(index, 10)];
                    if (input) {{
                        if (input.type === ""checkbox"" || input.type === ""radio"") {{
                            input.checked = true;
                        }} else if (input.type === ""number"") {{
                            input.value = value;
                        }}
                    }}
                }});

                // Trigger any change events to ensure dependent UI updates
                urlInputs.forEach(input => {{
                    const event = new Event('change');
                    input.dispatchEvent(event);
                }});
            }}
        }} catch (error) {{
            console.error(""Error decoding configuration:"", error);
        }}
    }}


    // --------------------------------------------------------------
    // Dynamic cost preview updates
    // --------------------------------------------------------------
    const inputs = document.querySelectorAll('#{name}-row input');
    const totalPriceLabel = document.getElementById('{name}-total-price');

    function {name}_calculateTotal() {{
        let smallTotal = 0;
        let bigTotal = 0;

        inputs.forEach(input => {{
            if (    (input.type == ""checkbox"" && input.checked) ||
                    (input.type == ""radio"" && input.checked) ||
                    (input.type == ""number"" && input.value > 0)
                ) {{
                let price = input.getAttribute(""s-price"");
                let value = price.split('-').map(v => parseFloat(v));

                if (input.type == ""number"") {{
                    value = value.map(v => v * input.value);
                }}

                if (price.includes('%')) {{
                    if (value.length === 1) {{
                        smallTotal *= 1 + (value[0] / 100);
                        bigTotal *= 1 + (value[0] / 100);
                    }} else {{
                        smallTotal *= 1 + (value[0] / 100);
                        bigTotal *= 1 + (value[1] / 100);
                    }}
                }}
                else {{
                    if (value.length === 1) {{
                        smallTotal += value[0];
                        bigTotal += value[0];
                    }} else {{
                        smallTotal += value[0];
                        bigTotal += value[1];
                    }}
                }}
            }}
        }});

        if (bigTotal === smallTotal) {{
            totalPriceLabel.innerHTML = `Total: $${{bigTotal.toFixed(2)}}`;
        }}
        else {{
            totalPriceLabel.innerHTML = `Minimum total: $${{smallTotal.toFixed(2)}}<br>Maximum total: $${{bigTotal.toFixed(2)}}`;
        }}
    }}

    inputs.forEach(input => {{
        input.addEventListener('change', {name}_calculateTotal);
    }});

    // Initial calculation in case some options are preselected
    {name}_calculateTotal();
}});
            ";
        javascript.InnerHtml.AppendHtml(script);

        TagBuilder total = new("h5");
        total.Attributes.Add("id", $"{name}-total-price");
        total.AddCssClass("col-sm-12 pt-0");

        element.InnerHtml.AppendHtml(total);
        element.InnerHtml.AppendHtml(javascript);

        return element;
    }

    /// <summary>
    /// Get the HTML to export and import the values of a price preview table
    /// </summary>
    /// <param name="data">Datatable to use, create with <see cref="NewTable"/> and fill with <see cref="NewRow(DataTable, PriceRowType, object[])"/></param>
    /// <returns></returns>
    public static IHtmlContent TableExportScript(DataTable data)
    {
        string name = GetNameJs(data.TableName);

        TagBuilder element = new("div");
        element.AddCssClass("d-grid gap-2 mb-3");

        TagBuilder btn = new("button");
        btn.Attributes.Add("type", "button");
        btn.Attributes.Add("class", "btn btn-primary");
        btn.Attributes.Add("id", $"{name}-export");
        btn.InnerHtml.AppendHtml($"Export preview:<br>{data.TableName}");

        string script = $@"
const {name}inputs = document.querySelectorAll('#{name}-row input');
const {name}generateLinkButton = document.getElementById('{name}-export');

{name}generateLinkButton.addEventListener('click', function () {{
    const inputs = document.querySelectorAll('#{name}-row input');
    let compactString = ""{name},"";

    inputs.forEach((input, index) => {{
        if ((input.type === ""checkbox"" && input.checked) ||
            (input.type === ""radio"" && input.checked) ||
            (input.type === ""number"" && input.value > 0)) {{
            compactString += `${{index}}-${{input.value}},`;
        }}
    }});

    // Encode compactString
    const encodedString = btoa(compactString); // Base64 encode the string
    const baseUrl = window.location.href.split('?')[0];
    const generatedUrl = `${{baseUrl}}?config=${{encodedString}}`;

    // Copy to clipboard
    navigator.clipboard.writeText(generatedUrl).then(() => {{
        const originalWidth = {name}generateLinkButton.offsetWidth;
        const originalHeight = {name}generateLinkButton.offsetHeight;
        {name}generateLinkButton.style.width = `${{originalWidth}}px`;
        {name}generateLinkButton.style.height = `${{originalHeight}}px`;
        {name}generateLinkButton.textContent = 'Copied!';

        setTimeout(() => {{
            {name}generateLinkButton.innerHTML = 'Export preview:<br>{data.TableName}'; // Revert content
            {name}generateLinkButton.style.width = ''; // Remove width lock
            {name}generateLinkButton.style.height = ''; // Remove height lock
        }}, 2000);
    }}).catch(err => {{
        console.error('Failed to copy URL: ', err);
    }});
}});
            ";

        TagBuilder javascript = new("script");
        javascript.InnerHtml.AppendHtml(script);

        element.InnerHtml.AppendHtml(btn);
        element.InnerHtml.AppendHtml(javascript);
        return element;
    }

    /// <summary>
    /// Get the HTML for a buttons table, useful for socials
    /// </summary>
    /// <param name="buttons">Socials to include</param>
    /// <returns></returns>
    public static IHtmlContent GetButtonsTable(Tuple<string, string, string>[] buttons)
    {
        TagBuilder row = new("div");
        row.AddCssClass("row");

        for (int j = 0;  j < buttons.Length; j++)
        {
            string text = buttons[j].Item1;
            string icon = buttons[j].Item2;
            string url = buttons[j].Item3;

            TagBuilder a = new("a");
            a.AddCssClass(j == 0 ? "d-grid gap-2" : "d-grid gap-2 mt-3");
            a.Attributes.Add("target", "_blank");
            a.Attributes.Add("href", url);

            TagBuilder btn = new("button");
            btn.Attributes.Add("type", "button");
            btn.AddCssClass("btn btn-primary");

            if (icon != "")
            {
                TagBuilder i = new("i");
                i.AddCssClass(icon);
                btn.InnerHtml.AppendHtml(i);
            }

            btn.InnerHtml.AppendHtml(text);
            a.InnerHtml.AppendHtml(btn);
            row.InnerHtml.AppendHtml(a);
        }

        return row;
    }

    /// <summary>
    /// Get the HTML for an artist's TOS
    /// </summary>
    /// <param name="tos">TOS to include</param>
    /// <returns></returns>
    public static IHtmlContent GetTosTable(Tuple<string, string>[] tos)
    {
        int i = 1;
        TagBuilder row = new("div");
        row.AddCssClass("row");

        TagBuilder col = new("div");
        col.AddCssClass("col-sm-12");
        
        TagBuilder accodition = new("div");
        accodition.AddCssClass("accordion accordion-flush");
        accodition.Attributes.Add("id", "accoditionTos");

        foreach(Tuple<string, string> t in tos)
        {
            string key = t.Item1;
            string text = t.Item2;

            TagBuilder item = new("div");
            item.AddCssClass("accordion-item");

            TagBuilder h2 = new("h2");
            h2.AddCssClass("accordion-header");
            h2.Attributes.Add("id", $"flush-heading{i}");

            TagBuilder h2Button = new("button");
            h2Button.AddCssClass(i == 1 ? "accordion-button collapsed" : "accordion-button");
            h2Button.Attributes.Add("type", "button");
            h2Button.Attributes.Add("data-bs-toggle", "collapse");
            h2Button.Attributes.Add("data-bs-target", $"#flush-collapse{i}");
            h2Button.Attributes.Add("aria-expanded", i == 1 ? "true" : "false");
            h2Button.Attributes.Add("aria-controls", $"flush-collapse{i}");

            h2Button.InnerHtml.AppendHtml($"{i}. {key}");
            h2.InnerHtml.AppendHtml(h2Button);
            item.InnerHtml.AppendHtml(h2);


            TagBuilder bodyContainer = new("div");
            bodyContainer.AddCssClass(i == 1 ? "accordion-collapse collapse show" : "accordion-collapse collapse");
            bodyContainer.Attributes.Add("id", $"flush-collapse{i}");
            bodyContainer.Attributes.Add("aria-labelledby", $"flush-heading{i}");
            bodyContainer.Attributes.Add("data-bs-parent", "#accoditionTos");

            TagBuilder accoditionBody = new("div");
            accoditionBody.AddCssClass("accodition-body");

            accoditionBody.InnerHtml.AppendHtml(text);
            bodyContainer.InnerHtml.AppendHtml(accoditionBody);
            item.InnerHtml.AppendHtml(bodyContainer);

            accodition.InnerHtml.AppendHtml(item);
            i++;
        }

        col.InnerHtml.AppendHtml(accodition);
        row.InnerHtml.AppendHtml(col);

        return row;
    }

    /// <summary>
    /// Get the HTML to display a process table
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IHtmlContent GetProcessTable(Tuple<string>[] data)
    {
        TagBuilder activity = new("div");
        activity.AddCssClass("activity");

        string[] colors = ["text-success", "text-danger", "text-primary", "text-info", "text-warning", "text-muted"];
        for (int i = 0; i < data.Length; i++)
        {
            string time = $"{i+1}.";
            string text = data[i].Item1;

            TagBuilder item = new("div");
            item.AddCssClass("activity-item d-flex");

            TagBuilder label = new("div");
            label.AddCssClass("activite-label");
            label.Attributes.Add("style", "min-width: 24px");
            label.InnerHtml.AppendHtml(time);

            TagBuilder icon = new("i");
            icon.AddCssClass($"bi bi-circle-fill activity-badge {colors[i%colors.Length]} align-self-start");

            TagBuilder content = new("div");
            content.AddCssClass("activity-content");
            content.InnerHtml.AppendHtml(text);

            item.InnerHtml.AppendHtml(label);
            item.InnerHtml.AppendHtml(icon);
            item.InnerHtml.AppendHtml(content);
            activity.InnerHtml.AppendHtml(item);
        }

        return activity;
    }

    /// <summary>
    /// Get the HTML for a story's table
    /// </summary>
    /// <param name="chapters">Story chapters to include</param>
    /// <returns></returns>
    public static IHtmlContent GetStoryTable(Tuple<string, Tuple<string, string>[]>[] chapters)
    {
        int i = 0, j = 0;
        string accoditionName = "accoditionStory";
        string[] colors = ["text-primary", "text-info"];

        TagBuilder main = new("div");
        main.AddCssClass("activity accordion accordion-flush");
        main.Attributes.Add("id", accoditionName);

        foreach (Tuple<string, Tuple<string, string>[]> ch in chapters)
        {
            string title = ch.Item1;
            Tuple<string, string>[] subitems = ch.Item2;
            i++;

            TagBuilder itemActivity = new("div");
            itemActivity.AddCssClass("accodition-item activity-item d-flex");

            TagBuilder itemActivityLabel = new("div");
            itemActivityLabel.AddCssClass("activite-label");
            itemActivityLabel.Attributes.Add("style", "min-width:0px;");

            TagBuilder itemActivityIcon = new("i");
            itemActivityIcon.AddCssClass($"bi bi-circle-fill activity-badge {colors[0]} align-self-start");

            TagBuilder itemActivityContent = new("div");
            itemActivityContent.AddCssClass("activity-content");
            itemActivityContent.Attributes.Add("style", "margin-top: -15px; width:100%;");

            TagBuilder itemHeading = new("div");
            itemHeading.AddCssClass("accordion-header");
            itemHeading.Attributes.Add("id", $"flush-heading{i}");

            TagBuilder itemBody = new("div");
            itemBody.AddCssClass("accordion-body");
            itemBody.Attributes.Add("style", "padding-bottom: 0px;");

            TagBuilder itemHeadingButton = new("button");
            itemHeadingButton.AddCssClass("accordion-button collapsed");
            itemHeadingButton.Attributes.Add("data-bs-toggle", "collapse");
            itemHeadingButton.Attributes.Add("data-bs-target", $"#flush-collapse{i}");
            itemHeadingButton.Attributes.Add("aria-expanded", "false");
            itemHeadingButton.Attributes.Add("aria-controls", $"flush-collapse{i}");
            itemHeadingButton.InnerHtml.AppendHtml(title);

            TagBuilder itemContent = new("div");
            itemContent.AddCssClass("accordion-collapse collapse");
            itemContent.Attributes.Add("id", $"flush-collapse{i}");
            itemContent.Attributes.Add("aria-labelledby", $"flush-heading{i}");
            itemContent.Attributes.Add("data-bs-parent", $"#{accoditionName}");

            if (subitems.Length > 1)
            {
                j = 0;
                TagBuilder chapterHtml = new("div");
                chapterHtml.AddCssClass("accordion accordion-flush");
                chapterHtml.Attributes.Add("id", $"{accoditionName}{i}");

                foreach (Tuple<string, string> chapter in subitems)
                {
                    j++;
                    string chapterName = chapter.Item1;
                    string chapterContent = chapter.Item2;

                    TagBuilder chapterActivity = new("div");
                    chapterActivity.AddCssClass("accodition-item activity-item d-flex");

                    TagBuilder chapterActivityLabel = new("div");
                    chapterActivityLabel.AddCssClass("activite-label");
                    chapterActivityLabel.Attributes.Add("style", "min-width:0px;");

                    TagBuilder chapterActivityIcon = new("i");
                    chapterActivityIcon.AddCssClass($"bi bi-circle-fill activity-badge {colors[1]} align-self-start");

                    TagBuilder chapterActivityContent = new("div");
                    chapterActivityContent.AddCssClass("activity-content");
                    chapterActivityContent.Attributes.Add("style", "margin-top: -15px; width:100%;");

                    TagBuilder chapterItemHeading = new("div");
                    chapterItemHeading.AddCssClass("accordion-header");
                    chapterItemHeading.Attributes.Add("id", $"flush-heading{i}{j}");

                    TagBuilder chapterItemHeadingButton = new("button");
                    chapterItemHeadingButton.AddCssClass("accordion-button collapsed");
                    chapterItemHeadingButton.Attributes.Add("data-bs-toggle", "collapse");
                    chapterItemHeadingButton.Attributes.Add("data-bs-target", $"#flush-collapse{i}{j}");
                    chapterItemHeadingButton.Attributes.Add("aria-expanded", "false");
                    chapterItemHeadingButton.Attributes.Add("aria-controls", $"flush-collapse{i}{j}");
                    chapterItemHeadingButton.InnerHtml.AppendHtml(chapterName);

                    TagBuilder chapterItemBody = new("div");
                    chapterItemBody.AddCssClass("accordion-body");
                    chapterItemBody.Attributes.Add("style", "padding-bottom: 0px;");

                    TagBuilder chapterItemBodyContent = new("div");
                    chapterItemBodyContent.AddCssClass("accordion-collapse collapse");
                    chapterItemBodyContent.Attributes.Add("id", $"flush-collapse{i}{j}");
                    chapterItemBodyContent.Attributes.Add("aria-labelledby", $"flush-heading{i}{j}");
                    chapterItemBodyContent.Attributes.Add("data-bs-parent", $"#{accoditionName}{i}");
                    chapterItemBodyContent.InnerHtml.AppendHtml(chapterContent);


                    chapterItemHeading.InnerHtml.AppendHtml(chapterItemHeadingButton);
                    chapterItemBody.InnerHtml.AppendHtml(chapterItemHeading);
                    chapterItemBody.InnerHtml.AppendHtml(chapterItemBodyContent);
                    chapterActivityContent.InnerHtml.AppendHtml(chapterItemBody);

                    chapterActivity.InnerHtml.AppendHtml(chapterActivityLabel);
                    chapterActivity.InnerHtml.AppendHtml(chapterActivityIcon);
                    chapterActivity.InnerHtml.AppendHtml(chapterActivityContent);

                    chapterHtml.InnerHtml.AppendHtml(chapterActivity);
                }
                itemContent.InnerHtml.AppendHtml(chapterHtml);
            }
            else
            {
                itemContent.InnerHtml.AppendHtml(subitems[0].Item2);
            }

            itemHeading.InnerHtml.AppendHtml(itemHeadingButton);
            itemBody.InnerHtml.AppendHtml(itemHeading);
            itemBody.InnerHtml.AppendHtml(itemContent);
            itemActivityContent.InnerHtml.AppendHtml(itemBody);

            itemActivity.InnerHtml.AppendHtml(itemActivityLabel);
            itemActivity.InnerHtml.AppendHtml(itemActivityIcon);
            itemActivity.InnerHtml.AppendHtml(itemActivityContent);

            main.InnerHtml.AppendHtml(itemActivity);
        }

        return main;
    }

    public static IHtmlContent GetCharacterStatsTable(List<CharacterVersion[]> versions)
    {
        TagBuilder table = new("table");
        table.AddCssClass("table table-striped");

        TagBuilder tableHead = new("thead");
        TagBuilder tableRow = new("tr");

        TagBuilder tableElement = new ("th");
        tableElement.Attributes.Add("scope", "col");
        tableElement.InnerHtml.Append("#");
        tableRow.InnerHtml.AppendHtml(tableElement);

        string[] headers = ["STR", "INT", "MAN", "GMN", "AMN", "AGE", "HGT"];
        foreach (string header in headers)
        {
            tableElement = new("th");
            tableElement.Attributes.Add("scope", "col");
            tableElement.AddCssClass("text-center");
            tableElement.InnerHtml.Append(header);
            tableRow.InnerHtml.AppendHtml(tableElement);
        }
        tableHead.InnerHtml.AppendHtml(tableRow);

        TagBuilder tableBody = new("tbody");
        foreach (CharacterVersion[] version in versions)
        {
            for (int j = 0; j < version.Length; j++)
            {
                tableRow = new("tr");
                if (j == 0)
                {
                    tableElement = new("td");
                    tableElement.Attributes.Add("scope", "row");
                    tableElement.Attributes.Add("rowspan", version.Length.ToString());
                    tableElement.InnerHtml.Append(version[j].AltName);
                    tableRow.InnerHtml.AppendHtml(tableElement);
                }
                string[] values = [
                    version[j].Strength.ToString(),
                    version[j].Intelligence.ToString(),
                    version[j].Mana?.ToString() ?? "NA",
                    version[j].ManaGem?.ToString() ?? "NA",
                    version[j].ManaAscended?.ToString() ?? "NA",
                    version[j].Age.ToString(),
                    version[j].Height.ToString(),
                    ];
                foreach (string value in values)
                {
                    tableElement = new("td");
                    tableElement.AddCssClass("text-center");
                    tableElement.InnerHtml.Append(value);
                    tableRow.InnerHtml.AppendHtml(tableElement);
                }
                tableBody.InnerHtml.AppendHtml(tableRow);
            }
        }

        table.InnerHtml.AppendHtml(tableHead);
        table.InnerHtml.AppendHtml(tableBody);

        return table;
    }

}
