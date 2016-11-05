$(function () {
    $("[id$='AddAdmin']").on("click", function (event) {

        $("[id$='SuccessDiv']").hide();
        $("[id$='ErrorDiv']").hide();
        var formValidation = $("[id$='RegisterForm']").valid();

        if (formValidation == true) {
            PostFarmerDetailData();
        }
    })
})

function PostFarmerDetailData() {

    var formData = $("[id$='RegisterForm']").serializeArray();
    $.each(formData, function (index, value) {
        value.name = value.name.replace("Register.", "");
    })
    var parameterData = {};
    $.each(formData, function (index, property) {
        parameterData[property.name] = property.value;
    })

    $.ajax({
        type: 'post',
        datatype: 'json',
        url: urlForRegisterUser,
        data: { "registerformString": JSON.stringify(parameterData) },
        success: function (response) {
            if (response != "") {
                if (response.success == true) {
                    //$("[id$='SuccessText]").html("Admin Created");
                    //$("[id$='SuccessDiv']").show();
                    window.location.reload();
                    $("[id$='SuccessText]").html(response.ValidationMessages);
                    $("[id$='SuccessDiv']").show();
                   
                   
                }
                else if (response.success == false) {
                    $("[id$='ErrorText']").html(response.ValidationMessages);
                    $("[id$='ErrorDiv']").show();
                }
            }
        }
    });
}