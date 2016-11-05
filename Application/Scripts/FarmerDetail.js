$(function () {
    DisablePrecidingDropdown('CurrentYears');
    DisablePrecidingDropdown('lastYears');

    if (actionType == "Insert") {
        //FillDropDownValue();
    }

    $("[id$='btnAdd']").on("click", function (event) {
        //$("[id$='ddlFarmerTypeErrorMsg']").html("")

        var formValidation = $("[id$='farmerDetailForm']").valid();
        //formValidation = ValidateFarmerTypeDropdown();
        //formValidation = ValidateCropDropDowns('CurrentYears');
        //formValidation = ValidateCropDropDowns('lastYears');
        
        if (formValidation == true) {
            PostFarmerDetailData();
        }

    })
    $("[id$='ddlPreviousYearCrop']").on("change", function (event) {
        DisablePrecidingDropdown('CurrentYears');
        DisablePrecidingDropdown('lastYears');
        //ValidateCropDropDowns('CurrentYears');
        //ValidateCropDropDowns('lastYears');

    })
    //$("[id$='ddlFarmerType']").on("change", function (event) {
    //    ValidateFarmerTypeDropdown();

    //})

    $("[id$='btnBack']").on("click", function () {
        window.location.href = urlForRedirectingDetailPage;
    });
    $("[id$='btnCancelAdd']").on("click", function () {
        window.location.href = urlForRedirectingDetailPage;
    });

    $("[id$='btnAddConsumption']").on("click", function () {
        var newConsumptionTrHtml = $("[class$='divHideConsumptionTr']").find($('[id$="tempConsumptionTbl"]')).children('tbody').html();
        $(newConsumptionTrHtml).insertBefore($("[class$='hideConsumptionDetailInsertBefore']"));

    })

    $("[id$='btnRemoveConsumption']").on("click", function () {
        var consumptionMappingCount = 0;
        $.each($("[id='farmerDetailAddTbl']").find($("[class$='trConsumptionMapping']")), function () {
            consumptionMappingCount = consumptionMappingCount + 1;

        });
        if (consumptionMappingCount > 0) {
            $("[class$='hideConsumptionDetailInsertBefore']").prev().remove();
            $("[class$='hideConsumptionDetailInsertBefore']").prev().remove();
        }
    })

    $("[id$='btnAddLand']").on("click", function () {
        var newLandTrHtml = $("[class$='divHideLandTr']").find($('[id$="tempLandTbl"]')).children('tbody').html();
        $(newLandTrHtml).insertBefore($("[class$='hideLandDetailInsertBefore']"));

    })

    $("[id$='btnRemoveLand']").on("click", function () {
        var LandMappingCount = 0;
        $.each($("[id='farmerDetailAddTbl']").find($("[class$='trLandMapping']")), function () {
            LandMappingCount = LandMappingCount + 1;

        });
        if (LandMappingCount < 2) {
            alert("One Land detail is mendetory");
        }
        else {
            $("[class$='hideLandDetailInsertBefore']").prev().remove();
            $("[class$='hideLandDetailInsertBefore']").prev().remove();
        }
    })

    $("[id$='btnAddCrop']").on("click", function () {
        var newCropTrHtml = $("[class$='divHideCropTr']").find($('[id$="tempCropTbl"]')).children('tbody').html();
        $(newCropTrHtml).insertBefore($("[class$='hideCropDetailInsertBefore']"));

    })

    $("[id$='btnRemoveCrop']").on("click", function () {
        var CropMappingCount = 0;
        $.each($("[id='farmerDetailAddTbl']").find($("[class$='trCropMapping']")), function () {
            CropMappingCount = CropMappingCount + 1;

        });
        if (CropMappingCount < 2) {
            alert("One Crop detail is mendetory");
        }
        else {
            $("[class$='hideCropDetailInsertBefore']").prev().remove();
            $("[class$='hideCropDetailInsertBefore']").prev().remove();
        }
    })

    $("[id$='btnAddPesticides']").on("click", function () {
        var newPesticidesTrHtml = $("[class$='divHidePestiesTr']").find($('[id$="tempPestiesTbl"]')).children('tbody').html();
        $(newPesticidesTrHtml).insertBefore($("[class$='hidePestiesDetailInsertBefore']"));

    })

    $("[id$='btnRemovePesticides']").on("click", function () {
        var pestiesMappingCount = 0;
        $.each($("[id='farmerDetailAddTbl']").find($("[class$='trPestiesMapping']")), function () {
            pestiesMappingCount = pestiesMappingCount + 1;

        });
        if (pestiesMappingCount < 2) {
            alert("One Pesticide detail is mendetory");
        }
        else {
            $("[class$='hidePestiesDetailInsertBefore']").prev().remove();
            $("[class$='hidePestiesDetailInsertBefore']").prev().remove();
        }
    })

    $("[id$='btnAddSource']").on("click", function () {
        var newIsourceTrHtml = $("[class$='divHideIsourceTr']").find($('[id$="tempIsourceTbl"]')).children('tbody').html();
        $(newIsourceTrHtml).insertBefore($("[class$='hideInputSourceDetailInsertBefore']"));

    })

    $("[id$='btnRemoveSource']").on("click", function () {
        var iSourceMappingCount = 0;
        $.each($("[id='farmerDetailAddTbl']").find($("[class$='trInputSourceMapping']")), function () {
            iSourceMappingCount = iSourceMappingCount + 1;

        });
        if (iSourceMappingCount < 2) {
            alert("One Input Source detail is mendetory");
        }
        else {
            $("[class$='hideInputSourceDetailInsertBefore']").prev().remove();
            $("[class$='hideInputSourceDetailInsertBefore']").prev().remove();
        }
    })

    $("[id$='ddlPocket']").change(function () {
        
        var pocketId = $("[id$='ddlPocket']").val();
        
        if (pocketId > 0) {
            ClearDropdown($("[id$='ddlCrops']"))
            ClearDropdown($("[id$='ddlVillage']"))

            var parameterData = {};
            parameterData["pocketId"] = pocketId;
            BindDropdownWithParameterForFarmer(parameterData, $("[id$='ddlSubDistrict']"), urlForPageInitialValue);
            
        }
        else {
            ClearDropdown($("[id$='ddlCrops']"))
            ClearDropdown($("[id$='ddlVillage']"))
        }
    });
})

function PostFarmerDetailData() {

    var formData = $("[id$='farmerDetailForm']").serializeArray();
    $.each(formData, function (index, value) {
        value.name = value.name.replace("farmerDetail.", "");
    })
    var parameterData = {};
    $.each(formData, function (index, property) {
        parameterData[property.name] = property.value;
    })

    var lastYearCropObjectList = [];
    var lastYearCrop = '';
    var lastYearCropAcre = '';
    $(".lastYears").each(function () {
        lastYearCrop = $(this).find($("[id$='ddlPreviousYearCrop']")).val()
        lastYearCropAcre = $(this).find($("[id$='txtprivouseCropAcre']")).val()

        lastYearCropObject = {};
        lastYearCropObject.cropId = lastYearCrop;
        lastYearCropObject.acre = lastYearCropAcre;
        lastYearCropObjectList.push(lastYearCropObject);

    })

    parameterData.lastYearCropObjectList = lastYearCropObjectList;


    var currentYearCrop = '';
    var currentYearCropAcre = '';
    var currentYearCropObjectList = [];
    $(".CurrentYears").each(function () {
        currentYearCrop = $(this).find($("[id$='ddlPreviousYearCrop']")).val()
        currentYearCropAcre = $(this).find($("[id$='txtprivouseCropAcre']")).val()

        var currentYearCropObject = new Object();
        currentYearCropObject.cropId = currentYearCrop;
        currentYearCropObject.acre = currentYearCropAcre;
        currentYearCropObjectList.push(currentYearCropObject);
    })
    parameterData.currentYearCropObjectList = currentYearCropObjectList;

    var pestice = '';
    var pesticeAcre = '';
    var pesticeObjectList = [];
    $(".PesticeClass").each(function () {
        pestice = $(this).find($("[id$='txtPesticesUsed']")).val()
        pesticeAcre = $(this).find($("[id$='txtPesticesUsedinAcre']")).val()

        var pesticeObject = new Object();
        pesticeObject["pesticesName"] = pestice;
        pesticeObject["acre"] = pesticeAcre;
        pesticeObjectList.push(pesticeObject);
    })
    parameterData.pesticeObjectList = pesticeObjectList;

    var ajaxUrl = '';
    if (actionType == "Update") {
        ajaxUrl = urlForPostingUpdatedData;
    }
    if (actionType == 'Insert') {
        ajaxUrl = urlForPostingNewFaData;
    }

    $.ajax({
        type: 'post',
        datatype: 'json',
        url: ajaxUrl,
        data: { "farmerDetailString": JSON.stringify(parameterData) },
        success: function () {
            alert("Data Successfully Inserted")
            window.location.href = urlForRedirectingDetailPage;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}


function DisablePrecidingDropdown(className) {
    var precidingDisable = false;
    var disableSecondDropDown = false;
    $("." + className).each(function () {
        var dropDownValue = $(this).find($("[id$='ddlPreviousYearCrop']")).val();
        var isFirstDropdown = $(this).hasClass("firstDropDown");
        if (isFirstDropdown == true) {
            if (dropDownValue == '-1') {
                $(this).find($("[id$='txtprivouseCropAcre']")).val('');
                disableSecondDropDown = true;

            }
            return;
        }

        if (precidingDisable == true || disableSecondDropDown == true) {
            $(this).find($("[id$='ddlPreviousYearCrop']")).val("-1");
            $(this).find($("[id$='ddlPreviousYearCrop']")).prop("disabled", true);

            $(this).find($("[id$='txtprivouseCropAcre']")).prop("disabled", true);
            $(this).find($("[id$='txtprivouseCropAcre']")).val('');
            return;
        }
        else {
            $(this).find($("[id$='ddlPreviousYearCrop']")).prop("disabled", false);
            $(this).find($("[id$='txtprivouseCropAcre']")).prop("disabled", false);

        }
        if (dropDownValue == '-1') {
            precidingDisable = true;
            $(this).find($("[id$='txtprivouseCropAcre']")).val('');

        }
    });
}

function ValidateFarmerTypeDropdown() {
    var farmerTypeDropDownValue = $("[id$='ddlFarmerType']").val();
    alert(farmerTypeDropDownValue);
    if (farmerTypeDropDownValue == '-1') {
        alert('in if');
        $("[id$='ddlFarmerTypeErrorMsg']").html("Required");
        return false;
    }
    return true;
}

function ValidateCropDropDowns(className) {
    var valid = true;
    $("." + className).each(function () {
        $(this).find($("[id$='txtprivouseCropAcreErrorMsg']")).html("");
        $(this).find($("[id$='txtprivouseCropAcreErrorMsg']")).html("");
        $(this).find($("[id$='ddlPreviousYearCropErrorMsg']")).html("");

        if (valid == false)
        {
            return;
        }

        var isFirstDropdown = $(this).hasClass("firstDropDown");
        if (isFirstDropdown == true) {
            var dropDownValue = $(this).find($("[id$='ddlPreviousYearCrop']")).val();
            if (dropDownValue == '-1') {
                $(this).find($("[id$='txtprivouseCropAcreErrorMsg']")).html("Required");
                $(this).find($("[id$='ddlPreviousYearCropErrorMsg']")).html("Required");
                valid = false;

            }
            return;
        }

        var isDropdownDisable = $(this).find($("[id$='ddlPreviousYearCrop']")).is(':disabled');
        if (isDropdownDisable == false) {
            if ($(this).find($("[id$='ddlPreviousYearCrop']")).val() != "-1") {
                if ($(this).find($("[id$='txtprivouseCropAcre']")).val() == '') {
                    $(this).find($("[id$='txtprivouseCropAcreErrorMsg']")).html("Required");
                    valid = false;
                }
            }
        }
    });
    return valid;
}
//function FillDropDownValue() {
   
//    $.ajax({
//        type: 'post',
//        datatype: 'json',
//        url: urlForPageInitialValue,
//        success: function (Result) {
            
//            BindDropdownWithJson($("[id$='ddlCrops']"), Result.crops)
//            BindDropdownWithJson($("[id$='ddlVillage']"), Result.villages)
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert("Status: " + textStatus); alert("Error: " + errorThrown);
//        }

//    });
function BindDropdownWithParameterForFarmer(parameterData, dropDownControl, serviceURL) {
    $.ajax({
        type: 'post',
        datatype: 'json',
        url: serviceURL,
        data: parameterData,
        success: function (Result) {

            ClearDropdown($("[id$='ddlCrops']"))
            ClearDropdown($("[id$='ddlVillage']"))

            var cropdata = Result.crops
            
            $.each(cropdata, function (key, value) {
               
                $("[id$='ddlCrops']").append($("<option></option>").val
                (value.Value).html(value.Text));
            });

            var villageData = Result.villages
            $.each(villageData, function (key, value) {
                $("[id$='ddlVillage']").append($("<option></option>").val
                (value.Value).html(value.Text));
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}