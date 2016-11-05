var stateList;
var districtList;
var subDistrictList;
var villageList;
$(function () {
    
    if (actionType == "Update")
    {
        var controlToBind = $("[class$='divSubDistrictVillageMapping']").find($("[id$='ddlSubDistrict']"));
        var districtId = $("[id$='ddlDistrict']").val();
        BindDropdown("districtId", districtId, controlToBind, urlForGetSubDistricts);
        $("[class$='trBtnVillageMapping']").show();
        $("[class$='trBtnCropsMapping']").show();
        $("[class$='trBtnFertilizerMapping']").show();
        FillDropDownValueForUpdate();
    }
    if (actionType == "Insert") {
        FillDropDownValue();
        $("[id$='rowSpacingBtwnBtn']").hide();
    }
    $("[id$='pocketCreationForm']").on("change", "[id$='ddlState']", function () {
        var stateId = $("[id$='ddlState']").val();
        if (stateId > 0)
        {
            BindDropdown("stateId", stateId, $("[id$='ddlDistrict']"), urlForGetDistricts);
        }
        else
        {
            ClearDropdown($("[id$='ddlDistrict']"))
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            RemvoveAllExtraVillageMapping();
            $("[class$='trBtnVillageMapping']").hide();
            $("[class$='trBtnCropsMapping']").hide();
            $("[class$='trBtnFertilizerMapping']").hide();
            $("[id$='rowSpacingBtwnBtn']").hide();
        }
    });
    $("[id$='pocketCreationForm']").on("change", "[id$='ddlDistrict']", function () {
        var districtId = $("[id$='ddlDistrict']").val();
        if (districtId > 0) {
            BindDropdown("districtId", districtId, $("[id$='ddlSubDistrict']"), urlForGetSubDistricts);
            $("[class$='trBtnVillageMapping']").show();
            $("[class$='trBtnCropsMapping']").show();
            $("[class$='trBtnFertilizerMapping']").show();
            $("[id$='rowSpacingBtwnBtn']").show();
        }
        else {
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            RemvoveAllExtraVillageMapping();
            $("[class$='trBtnVillageMapping']").hide();
            $("[class$='trBtnCropsMapping']").hide();
            $("[class$='trBtnFertilizerMapping']").hide();
            $("[id$='rowSpacingBtwnBtn']").hide();
        }
    });
    $("[id$='pocketCreationForm']").on("change", "[id$='ddlSubDistrict']", function () {
        var subDistrictId = $(this).val();
        var RespectedVillageControl = $(this).closest('tr').find($("[id$='ddlVillage']"));
        if (subDistrictId > 0) {
            BindDropdown("subDistrictId", subDistrictId, RespectedVillageControl, urlForGetVillages);
        }
        else {
            ClearDropdown(RespectedVillageControl);
        }
    });

    $("[id$='pocketCreationForm']").on("click", "[id$='btnAddVillage']", function () {
        var newVillageMappingTrHtml = $("[class$='divSubDistrictVillageMapping']").find($('[id$="tempVillageMappingTbl"]')).children('tbody').html();
        $(newVillageMappingTrHtml).insertBefore($("[class$='trInsertVillageMappingAfter']"));
        
       
    });
    $("[id$='pocketCreationForm']").on("click", "[id$='btnRemoveVillage']", function () {
        RemvoveVillageMapping();
    });




    $("[id$='pocketCreationForm']").on("click", "[id$='btnAddCrop']", function () {
        var newCropMappingTrHtml = $("[class$='divPocketCropsMapping']").find($('[id$="tempCropMappingTbl"]')).children('tbody').html();
        $(newCropMappingTrHtml).insertBefore($("[class$='trInsertCropMappingAfter']"));
    });
    $("[id$='pocketCreationForm']").on("click", "[id$='btnRemoveCrop']", function () {
        RemvoveCropsMapping();
    });




    $("[id$='pocketCreationForm']").on("click", "[id$='btnAddFertilizer']", function () {
        var newFertilizerMappingTrHtml = $("[class$='divPocketFertilizerMapping']").find($('[id$="tempFertilizerMappingTbl"]')).children('tbody').html();
        $(newFertilizerMappingTrHtml).insertBefore($("[class$='trInsertFertilizerMappingAfter']"));
    });
    $("[id$='pocketCreationForm']").on("click", "[id$='btnRemoveFertilizer']", function () {
        RemvoveFertilizerMapping();
    });





    $("[id$='btnSave']").on("click", function () {
        var formValidation = $("[id$='pocketCreationForm']").valid();
        if (formValidation == false) {
            alert("please provice required input fields")
            return false;
        }
        var formData = $("[id$='pocketCreationForm']").serializeArray();

        var parameterData = {};
        $.each(formData, function (index, property) {
            parameterData[property.name] = property.value;
        })

        
        var pocketInfo = {};
        pocketInfo.PocketID = parameterData['pocketInfo.PocketID'];
        pocketInfo.PocketName = parameterData['pocketInfo.PocketName'];
        pocketInfo.StateID = parameterData['pocketInfo.StateID'];
        pocketInfo.DistrictId = parameterData['pocketInfo.DistrictId'];
        pocketInfo.PocketStatusId = parameterData['pocketInfo.PocketStatusId'];

        var PocketVillageMappingList = [];
        $("[id='pocketDetailAddTbl']").find($("[class$='trSubDistrictVillageMapping']")).each(function () {
            pocketVillageMappingObject = {};
            pocketVillageMappingObject.Id = $(this).find($("[id$='txtVillageMappingId']")).val();
            pocketVillageMappingObject.SubDistrictId = $(this).find($("[id$='ddlSubDistrict']")).val();
            pocketVillageMappingObject.VillageId = $(this).find($("[id$='ddlVillage']")).val();
            pocketVillageMappingObject.IsActive = true;
            PocketVillageMappingList.push(pocketVillageMappingObject);
        });
        pocketInfo.PocketVillageMappingList = PocketVillageMappingList;

        var PocketCropMappingList = [];
        $("[id='pocketDetailAddTbl']").find($("[class$='trCropsMapping']")).each(function () {
            pocketCropsMappingObject = {};
            pocketCropsMappingObject.id = $(this).find($("[id$='txtCropMappingId']")).val();
            pocketCropsMappingObject.CropId = $(this).find($("[id$='ddlCrops']")).val();
            PocketCropMappingList.push(pocketCropsMappingObject);
        });
        pocketInfo.PocketCropMappingList = PocketCropMappingList;

        var PocketFertilizerMappingList = [];
        $("[id='pocketDetailAddTbl']").find($("[class$='trFertilizerMapping']")).each(function () {
            pocketFertilizerMappingObject = {};
            pocketFertilizerMappingObject.Id = $(this).find($("[id$='txtFertilizerMappingId']")).val();
            pocketFertilizerMappingObject.FertilizerId = $(this).find($("[id$='ddlFertilizer']")).val();
            PocketFertilizerMappingList.push(pocketFertilizerMappingObject);
        });
        pocketInfo.PocketFertilizerMappingList = PocketFertilizerMappingList;

        
        var PocketModel = {};
        PocketModel.pocketInfo = pocketInfo;



        var ajaxUrl = '';
        if (actionType == "Update") {
            ajaxUrl = urlForPostingUpdatedPocketData;
        }
        if (actionType == 'Insert') {
            ajaxUrl = urlForPostingNewPocketData;
        }

        $.ajax({
            type: 'post',
            datatype: 'json',
            url: ajaxUrl,
            data: { "pocketData": JSON.stringify(PocketModel) },
            success: function () {
                alert("Data Successfully Inserted")
                window.location.href = urlForRedirectingDetailPage;
                //success message mybe...
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }

        });


    });
    $("[id$='btnCancelAdd']").on("click", function () {
        window.location.href = urlForRedirectingDetailPage;
    });
    $("[id$='btnBack']").on("click", function () {
        window.location.href = urlForRedirectingDetailPage;
    });
});

function RemvoveVillageMapping()
{
    var villageMappingCount = 0;
    $.each($("[id='pocketDetailAddTbl']").find($("[class$='trSubDistrictVillageMapping']")), function () {
        villageMappingCount = villageMappingCount + 1;

    });
    if (villageMappingCount == 1) {
        alert("Atleast one village is required for pocket");
    }
    else {
        $("[class$='trInsertVillageMappingAfter']").prev().remove();
        $("[class$='trInsertVillageMappingAfter']").prev().remove();

    }
}
function RemvoveCropsMapping() {
    var cropsMappingCount = 0;
    $.each($("[id='pocketDetailAddTbl']").find($("[class$='trCropsMapping']")), function () {
        cropsMappingCount = cropsMappingCount + 1;

    });
    if (cropsMappingCount == 1) {
        alert("Atleast one crop is required for pocket");
    }
    else {
        $("[class$='trInsertCropMappingAfter']").prev().remove();
        $("[class$='trInsertCropMappingAfter']").prev().remove();

    }
}
function RemvoveFertilizerMapping() {
    var fertilizerMappingCount = 0;
    $.each($("[id='pocketDetailAddTbl']").find($("[class$='trFertilizerMapping']")), function () {
        fertilizerMappingCount = fertilizerMappingCount + 1;

    });
    if (fertilizerMappingCount == 1) {
        alert("Atleast one fertilizer is required for pocket");
    }
    else {
        $("[class$='trInsertFertilizerMappingAfter']").prev().remove();
        $("[class$='trInsertFertilizerMappingAfter']").prev().remove();

    }
}
function RemvoveAllExtraVillageMapping() {
    $.each($("[id='pocketDetailAddTbl']").find($("[class$='trSubDistrictVillageMapping']")), function () {

        var villageMappingCount = 0;
        $.each($("[id='pocketDetailAddTbl']").find($("[class$='trSubDistrictVillageMapping']")), function () {
            villageMappingCount = villageMappingCount + 1;

        });
        if (villageMappingCount > 1) {
            $("[class$='trInsertVillageMappingAfter']").prev().remove();
            $("[class$='trInsertVillageMappingAfter']").prev().remove();
        }
    });
   
}




function FillDropDownValue() {
   
    $.ajax({
        type: 'post',
        datatype: 'json',
        url: urlForPageInitialValue,
        success: function (Result) {
            BindDropdownWithJson($("[id$='ddlState']"), Result.states)
            BindDropdownWithJson($("[id$='ddlStatus']"), Result.pocketStatusList)
            BindDropdownWithJson($("[id$='ddlCrops']"), Result.crops)
            BindDropdownWithJson($("[id$='ddlFertilizer']"), Result.fertilizers)
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}
function FillDropDownValueForUpdate() {

    $.ajax({
        type: 'post',
        datatype: 'json',
        url: urlForPageInitialValue,
        success: function (Result) {
            BindDropdownWithJson($("[class$='divPocketCropsMapping']").find($("[id$='tempCropMappingTbl']")).find($("[id$='ddlCrops']")), Result.crops)
            BindDropdownWithJson($("[class$='divPocketFertilizerMapping']").find($("[id$='tempFertilizerMappingTbl']")).find($("[id$='ddlFertilizer']")), Result.fertilizers)
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }

    });
}
