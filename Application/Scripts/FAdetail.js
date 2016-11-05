$(function () {

    $("[id$='faDetailForm']").on("click", "[id$='btnAddExperience']", function () {

        var firstExperienceTr = $(this).closest("table").find($("[class$='experienceDetailTR']")).html();

        var experienceTrCount = 0;

        $(this).closest("table").find($("[class$='experienceDetailTR']")).each(function () {
            experienceTrCount = experienceTrCount + 1;
        })

        if (experienceTrCount < allowMaximumExperienceDetailToInsert) {
            var newExperienceTrHtml = $("[class$='hideExperienceTr']").find($('[id$="tempExperienceTbl"]')).children('tbody').html();
            newExperienceTrHtml =  newExperienceTrHtml ;
            
            var countPosition = 1;
            var lastExperienceTr;
            $(this).closest("table").find($("[class$='experienceDetailTR']")).each(function () {

                if (countPosition == experienceTrCount) {
                    lastExperienceTr = $(this);
                    return;
                }
                countPosition = countPosition + 1;
            })
            $(newExperienceTrHtml).insertAfter($(lastExperienceTr));
        }
        else {
            alert("You can insert up to " + allowMaximumExperienceDetailToInsert + " Experience detail.")
        }
    })

    $("[id$='faDetailForm']").on("click", "[id$='btnRemoveExperience']", function () {

        var currentButton = $(this);
        var experienceTrCount = 0;
        $(this).closest("table").find($("[class$='experienceDetailTR']")).each(function () {
            experienceTrCount = experienceTrCount + 1;
        })

        if (experienceTrCount < 2) {
            alert("One Experience detail is mendetory");
        }
        else {
            var countPosition = 1;
            var lastExperienceTr;
            $(this).closest("table").find($("[class$='experienceDetailTR']")).each(function () {

                if (countPosition == experienceTrCount) {
                    lastExperienceTr = $(this);
                    return;
                }
                countPosition = countPosition + 1;
            })
            $(lastExperienceTr).prev().remove();
            $(lastExperienceTr).remove();
        }
    })

    $("[id$='btnAddEducation']").on("click", function () {

        var educationTrCount = 0;

        $(this).closest("table").find($("[class$='educationDetailTR']")).each(function () {
            educationTrCount = educationTrCount + 1;
        })

        var newEducationTrHtml = $("[class$='hideEducationTr']").html()
        newEducationTrHtml = '<tr class="rowSpacing"></tr><tr class="educationDetailTR"><td>' + newEducationTrHtml + '</td></tr>';

        var countPosition = 1;
        var lastEducationTr;
        $(this).closest("table").find($("[class$='educationDetailTR']")).each(function () {

            if (countPosition == educationTrCount) {
                lastEducationTr = $(this);
                return;
            }
            countPosition = countPosition + 1;
        })
        $(newEducationTrHtml).insertAfter($(lastEducationTr));

    })

    $("[id$='btnRemoveEducation']").on("click", function () {

        var currentButton = $(this);
        var educationTrCount = 0;
        $(this).closest("table").find($("[class$='educationDetailTR']")).each(function () {
            educationTrCount = educationTrCount + 1;
        })

        if (educationTrCount < 2) {
            alert("One Education detail is mendetory");
        }
        else {
            var countPosition = 1;
            var lastEducationTr;
            $(this).closest("table").find($("[class$='educationDetailTR']")).each(function () {

                if (countPosition == educationTrCount) {
                    lastEducationTr = $(this);
                    return;
                }
                countPosition = countPosition + 1;
            })
            $(lastEducationTr).prev().remove();
            $(lastEducationTr).remove();
        }
    })

    $("[id$='btnAddTarget']").on("click", function () {
        var newTargetTrHtml = $("[class$='hideTargetTr']").find($('[id$="tempTargetTbl"]')).children('tbody').html();
        $(newTargetTrHtml).insertBefore($("[class$='hideTargetDetailInsertBefore']"));

    })

    $("[id$='btnRemoveTarget']").on("click", function () {
        var targetTrCount = 0;
        $(this).closest("table").find($("[class$='targetDetailTR']")).each(function () {
            targetTrCount = targetTrCount + 1;
        })
        if (targetTrCount < 2) {
            alert("One Target detail is mendetory");
        }
        else {
            $("[class$='hideTargetDetailInsertBefore']").prev().remove();
            $("[class$='hideTargetDetailInsertBefore']").prev().remove();
        }
    })

    $("[id$='faDetailForm']").on("click", "[id$='btnAddTargetCropMapping']", function () {
        var newTargetTrHtml = $("[class$='hideTargetCropMappingTr']").find($('[id$="tempCropMappingTbl"]')).children('tbody').html();
        $(newTargetTrHtml).insertBefore($(this).closest('table').find($("[class$='hideTargetMppingInsertBefore']")));
    });

    $("[id$='faDetailForm']").on("click", "[id$='btnRemoveTargetCropMapping']", function () {
        var CropMappingCount = 0;
        $(this).closest('table').find('tr').each(function () {
            if ($(this).attr('class') == 'targetMappingBeginRow') {
                CropMappingCount = CropMappingCount + 1;
            }
           
        });

        if (CropMappingCount < 2)
        {
            alert("Atleast one Crop detail for target is required");
            return false;
        }

        var removeStartFlag = false;
        $($(this).closest('table').find('tr').get().reverse()).each(function () {
            if ($(this).attr('class') == 'targetMappingEndRow') {
                removeStartFlag = true;
            }
            if (removeStartFlag) {
                if ($(this).attr('class') == 'targetMappingBeginRow') {
                    $(this).remove();
                    return false;
                }
                $(this).remove();
            }
        });
    });

    $("[id$='ddlExperience']").change(function () {

        if ($(this).val() == 'false' || $(this).val() == '')
        {
            if ($("[class$='expDropdownTr']").next().next().attr('class') == 'experienceDetailTR') {
                $("[class$='expDropdownTr']").next().remove();
                $("[class$='expDropdownTr']").next().remove();
                $("[class$='expDropdownTr']").next().remove();
                $("[class$='expDropdownTr']").next().remove();
            }
        }
        else
        {
            var newExperienceTrHtml = $("[class$='hideExperienceTr']").find($('[id$="tempExperienceTbl"]')).children('tbody').html();
            var newExperienceButtonTrHtml = $("[class$='hideExperienceButtonTr']").find($('[id$="tempExperienceBtnTbl"]')).children('tbody').html();
            $(newExperienceButtonTrHtml).insertAfter($("[class$='expDropdownTr']"));
            $(newExperienceTrHtml).insertAfter($("[class$='expDropdownTr']"));
        }
    });

    $("[id$='btnSave']").on("click", function () {
        var formValidation = $("[id$='faDetailForm']").valid();
        if (formValidation == false) {
            alert("please provice required input fields")
            return false;
        }
        var formData = $("[id$='faDetailForm']").serializeArray();
        
        var parameterData = {};
        $.each(formData, function (index, property) {
            parameterData[property.name] = property.value;
        })

        var faDetailEntities = {};
        faDetailEntities.Id = parameterData['faDetailEntities.Id'];
        faDetailEntities.FirstName = parameterData['faDetailEntities.FirstName'];
        faDetailEntities.MiddleName = parameterData['faDetailEntities.MiddleName'];
        faDetailEntities.LastName = parameterData['faDetailEntities.LastName'];
        faDetailEntities.BirthDate = parameterData['faDetailEntities.BirthDate'];
        faDetailEntities.EnrollDate = parameterData['faDetailEntities.EnrollDate'];
        faDetailEntities.FAdesignationId = parameterData['faDetailEntities.FAdesignationId'];
        faDetailEntities.IsExperienced = parameterData['faDetailEntities.IsExperienced'];
        faDetailEntities.Status = $("[id$='ddlStatus']").val();

        var AddressDetailEntities = {};
        AddressDetailEntities.Id = parameterData['faDetailEntities.AddressDetailEntities.Id'];
        AddressDetailEntities.FAdetailId = parameterData['faDetailEntities.Id'];
        AddressDetailEntities.PocketId = parameterData['faDetailEntities.AddressDetailEntities.PocketId'];
        AddressDetailEntities.Address = parameterData['faDetailEntities.AddressDetailEntities.Address'];
        AddressDetailEntities.Pincode = parameterData['faDetailEntities.AddressDetailEntities.Pincode'];
        AddressDetailEntities.StateId = parameterData['faDetailEntities.AddressDetailEntities.StateId'];
        AddressDetailEntities.SubDistrictId = parameterData['faDetailEntities.AddressDetailEntities.SubDistrictId'];
        AddressDetailEntities.District = parameterData['faDetailEntities.AddressDetailEntities.District'];
        AddressDetailEntities.Village = parameterData['faDetailEntities.AddressDetailEntities.Village'];
        AddressDetailEntities.ContactNo = parameterData['faDetailEntities.AddressDetailEntities.ContactNo'];
        AddressDetailEntities.MobileNo = parameterData['faDetailEntities.AddressDetailEntities.MobileNo'];
        AddressDetailEntities.EmailId = parameterData['faDetailEntities.AddressDetailEntities.EmailId'];
        faDetailEntities.AddressDetailEntities = AddressDetailEntities;

        var ApprovalEntities = {};
        ApprovalEntities.Id = parameterData['faDetailEntities.ApprovalEntities.Id'];
        ApprovalEntities.FAid = parameterData['faDetailEntities.Id'];
        ApprovalEntities.FAApprovedId = parameterData['faDetailEntities.ApprovalEntities.FAApprovedId'];
        ApprovalEntities.PocketId = parameterData['faDetailEntities.ApprovalEntities.PocketId'];
        ApprovalEntities.RecommandedBYSM = parameterData['faDetailEntities.ApprovalEntities.RecommandedBYSM'];
        faDetailEntities.ApprovalEntities = ApprovalEntities;

        var ExperienceDetailEntityList = [];
        $("[class$='faDetailMainTable']").find($("[class$='experienceDetailTR']")).each(function () {
            experienceDetailEntityObject = {};
            experienceDetailEntityObject.Id = $(this).find($("[id$='txtExpId']")).val();
            experienceDetailEntityObject.FAid = parameterData['faDetailEntities.Id'];
            experienceDetailEntityObject.OrganitionName = $(this).find($("[id$='OrganitionName']")).val();
            experienceDetailEntityObject.FromMonth = $(this).find($("[id$='ddlFromths']")).val();
            experienceDetailEntityObject.FromYear = $(this).find($("[id$='ddlFromYears']")).val();
            experienceDetailEntityObject.ToMonth = $(this).find($("[id$='ddlTomths']")).val();
            experienceDetailEntityObject.ToYear = $(this).find($("[id$='ddlToYears']")).val();
            experienceDetailEntityObject.Designation = $(this).find($("[id$='Designation']")).val();
            experienceDetailEntityObject.PaymentAgencyId = $(this).find($("[id$='PaymentAgencyId']")).val();
            experienceDetailEntityObject.SalaryPerMonth = $(this).find($("[id$='SalaryPerMonth']")).val();
            experienceDetailEntityObject.SalaryPerDay = $(this).find($("[id$='SalaryPerDay']")).val();
            experienceDetailEntityObject.DA = $(this).find($("[id$='DA']")).val();
            experienceDetailEntityObject.TA = $(this).find($("[id$='TA']")).val();
            experienceDetailEntityObject.Travel = $(this).find($("[id$='Travel']")).val();
            experienceDetailEntityObject.MobileAllowance = $(this).find($("[id$='MobileAllowance']")).val();
            experienceDetailEntityObject.WorkArea = $(this).find($("[id$='WorkArea']")).val();
            experienceDetailEntityObject.RecomandDealerInfo = $(this).find($("[id$='ddlRecomandedDealer']")).val();
            ExperienceDetailEntityList.push(experienceDetailEntityObject);
        })
        faDetailEntities.ExperienceDetailEntityList = ExperienceDetailEntityList;

        var EducationDetailEntityList = [];
        $("[class$='faDetailMainTable']").find($("[class$='educationDetailTR']")).each(function () {
            educationDetailEntityObject = {};
            educationDetailEntityObject.Id = $(this).find($("[id$='txtEduId']")).val();
            educationDetailEntityObject.FAid = parameterData['faDetailEntities.Id'];
            educationDetailEntityObject.Examination = $(this).find($("[id$='Examination']")).val();
            educationDetailEntityObject.University = $(this).find($("[id$='University']")).val();
            educationDetailEntityObject.Year = $(this).find($("[id$='ddlPassedYear']")).val();
            educationDetailEntityObject.Percentage = $(this).find($("[id$='Percentage']")).val();
            educationDetailEntityObject.Grade = $(this).find($("[id$='Grade']")).val();
            educationDetailEntityObject.Subjects = $(this).find($("[id$='Subjects']")).val();

            EducationDetailEntityList.push(educationDetailEntityObject);
        })
        faDetailEntities.EducationDetailEntityList = EducationDetailEntityList;
        var targetId = '';
        var TargetDetailEntityList = [];
        $("[class$='faDetailMainTable']").find($("[class$='targetDetailTR']")).each(function () {
            targetDetailEntityObject = {};
            targetDetailEntityObject.Id = $(this).find($("[id$='Id']")).val();
            targetId = $(this).find($("[id$='txttrgtId']")).val();
            targetDetailEntityObject.DealerId = $(this).find($("[id$='ddlDealerName']")).val();
            targetDetailEntityObject.FAid = parameterData['faDetailEntities.Id'];
            targetDetailEntityObject.VillageId = $(this).find($("[id$='ddlVillageName']")).val();

            var TargetCropsEntityMappingList = []
            $(this).find($("[class$='targetMappingBeginRow']")).each(function () {
                TargetCropsEntityMapping = {};

                var CropNameTr = $(this).next().next().next();
                TargetCropsEntityMapping.Id = $(CropNameTr).find($("[id$='txttrgtMappingId']")).val();
                TargetCropsEntityMapping.TargetId = targetId;
                TargetCropsEntityMapping.CropId = $(CropNameTr).find($("[id$='ddlCropId']")).val();
                TargetCropsEntityMapping.FromDate = $(CropNameTr).find($("[id$='FromDate']")).val();
                
                CropNameTr = $(CropNameTr).next().next();
                TargetCropsEntityMapping.ToDate = $(CropNameTr).find($("[id$='ToDate']")).val();

                CropNameTr = $(CropNameTr).next().next();
                TargetCropsEntityMapping.NoOfSamples = $(CropNameTr).find($("[id$='NoOfSamples']")).val();
                TargetCropsEntityMapping.NoOfDemos = $(CropNameTr).find($("[id$='NoOfDemos']")).val();

                CropNameTr = $(CropNameTr).next().next();
                TargetCropsEntityMapping.NoOfFarmerMeetings = $(CropNameTr).find($("[id$='NoOffarmerMeetings']")).val();
                TargetCropsEntityMapping.NoOfPrescriptions = $(CropNameTr).find($("[id$='NoOfPrescriptions']")).val();


                TargetCropsEntityMappingList.push(TargetCropsEntityMapping);
            });
            targetDetailEntityObject.TargetCropsEntityMappingList = TargetCropsEntityMappingList;

            TargetDetailEntityList.push(targetDetailEntityObject);
        })
        faDetailEntities.TargetDetailEntityList = TargetDetailEntityList;

        var faModel = {};
        faModel.faDetailEntities = faDetailEntities;

        var ajaxUrl = '';
        if (actionType == "Update")
        {
            ajaxUrl = urlForPostingUpdatedData;
        }
        if (actionType == 'Insert')
        {
            ajaxUrl = urlForPostingNewFaData;
        }

        $.ajax({
            type: 'post',
            datatype: 'json',
            url: ajaxUrl,
            data: { "faDetailJsonString": JSON.stringify(faModel) },
            success: function () {
                alert("Data Successfully Inserted")
                window.location.href = urlForRedirectingDetailPage;
                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }

        });
    })

    $("[id$='btnBack']").on("click", function () {
        window.location.href = urlForRedirectingDetailPage;
    });

    $("[id$='btnCancelAdd']").on("click", function () {
        window.location.href = urlForRedirectingDetailPage;
    });

    $("[id$='ddlState']").change(function () {

        var stateId = $("[id$='ddlState']").val();

        if (stateId > 0) {
            ClearDropdown($("[id$='ddlPocket']"))
            ClearDropdown($("[id$='ddlDistrict']"))
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            ClearDropdown($("[id$='ddlVillageName']"))

            var parameterData = {};
            parameterData["stateId"] = stateId;
            BindDropdownWithParameter(parameterData, $("[id$='ddlDistrict']"), urlForGetDistrictList);

        }
        else {
            ClearDropdown($("[id$='ddlPocket']"))
            ClearDropdown($("[id$='ddlDistrict']"))
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            ClearDropdown($("[id$='ddlVillageName']"))
        }
    });

    $("[id$='ddlDistrict']").change(function () {

        var districtId = $("[id$='ddlDistrict']").val();

        if (districtId > 0) {

            var parameterData = {};
            parameterData["districtId"] = districtId;
            var controlArray = []
            controlArray.push($("[id$='ddlPocket']"));
            controlArray.push($("[id$='ddlApprovalPocket']"));
            BindDropDownToControlArray(parameterData, controlArray, urlForGetDistrictPocketList);

        }
        else {
            ClearDropdown($("[id$='ddlPocket']"))
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            ClearDropdown($("[id$='ddlVillageName']"))
        }
    });

    $("[id$='ddlPocket']").change(function () {
        
        var pocketId = $("[id$='ddlPocket']").val();
        
        if (pocketId > 0) {
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            ClearDropdown($("[id$='ddlVillageName']"))

            var parameterData = {};
            parameterData["pocketId"] = pocketId;
            BindDropdownWithParameter(parameterData, $("[id$='ddlSubDistrict']"), urlForGetPocketSubDistrict);
            
        }
        else {
            ClearDropdown($("[id$='ddlSubDistrict']"))
            ClearDropdown($("[id$='ddlVillage']"))
            ClearDropdown($("[id$='ddlVillageName']"))
        }
    });

   

    $("[id$='ddlSubDistrict']").change(function () {

        var pocketId = $("[id$='ddlPocket']").val();
        var SubDistrictId = $("[id$='ddlSubDistrict']").val();

        if (pocketId > 0 && SubDistrictId > 0) {

            var parameterData = {};
            parameterData["pocketId"] = pocketId;
            parameterData["SubDistrictId"] = SubDistrictId;
            BindDropdownWithParameter(parameterData, $("[id$='ddlVillage']"), urlForGetPocketVillage);
            BindDropdownWithParameter(parameterData, $("[id$='ddlVillageName']"), urlForGetPocketVillage);

        }
        else {
            ClearDropdown($("[id$='ddlVillage']"))
            ClearDropdown($("[id$='ddlVillageName']"))
        }
    });
})


function ClearDropdown(dropDownControl) {
    $(dropDownControl).empty();
    $(dropDownControl).append($("<option></option>").val('').html(defaultDropdownText));
}

