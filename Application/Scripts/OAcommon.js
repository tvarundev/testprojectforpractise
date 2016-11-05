function BindDropdown(parameterName, parameterValue, dropDownControl, serviceURL) {
    var parameterData = {};
    parameterData[parameterName] = JSON.stringify(parameterValue);
    $.ajax({
        type: 'post',
        datatype: 'json',
        url: serviceURL,
        data: parameterData,
        success: function (Result) {
            ClearDropdown(dropDownControl);
            $.each(Result, function (key, value) {
                $(dropDownControl).append($("<option></option>").val
                (value.Value).html(value.Text));
            });
            return Result;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}

function BindDropdownWithParameter(parameterData, dropDownControl, serviceURL) {
    $.ajax({
        type: 'post',
        datatype: 'json',
        url: serviceURL,
        data: parameterData,
        success: function (Result) {
            ClearDropdown(dropDownControl);
            $.each(Result, function (key, value) {
                $(dropDownControl).append($("<option></option>").val
                (value.Value).html(value.Text));
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}

function BindDropDownToControlArray(parameterData, dropDownControlArray, serviceURL) {
    $.ajax({
        type: 'post',
        datatype: 'json',
        url: serviceURL,
        data: parameterData,
        success: function (Result) {
            $.each(dropDownControlArray, function (i, item) {

                ClearDropdown(item);
                $.each(Result, function (key, value) {
                    $(item).append($("<option></option>").val
                    (value.Value).html(value.Text));
                });
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}
function ClearDropdown(dropDownControl) {
    $(dropDownControl).empty();
    $(dropDownControl).append($("<option></option>").val('').html(defaultDropdownText));
}
function BindDropdownWithJson(dropdownControl, jsonData) {

    ClearDropdown(dropdownControl);
    $.each(jsonData, function (key, value) {
        $(dropdownControl).append($("<option></option>").val
        (value.Value).html(value.Text));
    });
}