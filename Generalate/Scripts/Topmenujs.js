//var baseUrl = (window.location).href; // You can also use document.URL
//var pagename = baseUrl.substring(baseUrl.lastIndexOf('=') + 1);
////alert(pagename)
////Congregation
//if (pagename == "meeting" || pagename == "council" || pagename == "commission" || pagename == "community" || pagename == "Institute"
//    || pagename == "society" || pagename == "Trust" || pagename == "staff" || pagename == "calender" || pagename == "calender"
//    || pagename == "ConCountCount") {
//    $.cookie("TopActiveMenu", 'Congregation');
//    $.cookie("TopActiveSubMenu", pagename);
//}
//if (pagename == "meeting") {
//    $(".nav-tabs").find('#GeneralateUnique1').show();
//    $("#GeneralateUnique1 a").click();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenOffMeet").addClass("active");
//    $("#CongGenCouncil").css("background", "#29b2e1");

//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");


//}
//if (pagename == "council") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $("#CouncilUnique1 a").click();
//    $(".nav-tabs").find('#CouncilUnique1').show();
//    // $("#CouncilUnique1").attr('active', true);
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");

//    $("#CongGenCouncil").addClass("active");
//    $("#CongGenCouncil").css("background", "#29b2e1");


//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//}

//if (pagename == "commission") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').show();
//    $("#CommissionUnique1 a").click();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenCommis").addClass("active");
//    $("#CongGenCommis").css("background", "#29b2e1");

//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (baseUrl.includes("community")) {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').show();
//    $("#CommUnique1 a").click();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenComm").addClass("active");
//    $("#CongGenComm").css("background", "#29b2e1");

//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "Institute") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').show();
//    $("#add1Unique1 a").click();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenInst").addClass("active");
//    $("#CongGenInst").css("background", "#29b2e1");

//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "society") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').show();
//    $("#SocietyUnique1 a").click();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenSociety").addClass("active");
//    $("#CongGenSociety").css("background", "#29b2e1");


//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "Trust") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').show();
//    $("#addUnique1 a").click();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");

//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "staff") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').show();
//    $("#StaffUnique1 a").click();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenStaff").addClass("active");
//    $("#CongGenStaff").css("background", "#29b2e1");


//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "calender") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').show();
//    $("#CalenderUnique1 a").click();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenCalender").addClass("active");
//    $("#CongGenCalender").css("background", "#29b2e1");


//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "calender") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').show();
//    $("#CalenderUnique1 a").click();
//    $(".nav-tabs").find('#CouncilCountUnique1').hide();

//    $("li a").removeClass("active");
//    $("#CongGenCalender").addClass("active");
//    $("#CongGenCalender").css("background", "#29b2e1");


//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

//if (pagename == "ConCountCount") {
//    $(".nav-tabs").find('#GeneralateUnique1').hide();
//    $(".nav-tabs").find('#CouncilUnique1').hide();
//    $(".nav-tabs").find('#CommissionUnique1').hide();
//    $(".nav-tabs").find('#CommUnique1').hide();
//    $(".nav-tabs").find('#add1Unique1').hide();
//    $(".nav-tabs").find('#SocietyUnique1').hide();
//    $(".nav-tabs").find('#addUnique1').hide();
//    $(".nav-tabs").find('#StaffUnique1').hide();
//    $(".nav-tabs").find('#CalenderUnique1').hide();
//    $(".nav-tabs").find('#CouncilCountUnique1').show();
//    $("#CouncilCountUnique1 a").click();

//    $("li a").removeClass("active");
//    $("#CongCouncilCount").addClass("active");
//    $("#CongCouncilCount").css("background", "#29b2e1");


//    $("#CongregationOpen a").addClass("active");
//    $("#CongregationOpen div").addClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//}

////Province
//if (baseUrl.includes("Province")) {
//    $.cookie("TopActiveMenu", 'Province');
//    $.cookie("TopActiveSubMenu", pagename);
//}
//if (baseUrl.includes("Province")) {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').show();
//    $("#ProOffMeetProUnique2 a").click();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    /////////////// tabs
//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");

//    //$("#ProOffMeetPro").addClass("active");
//    $("#ProOffMeetPro").css("background", "#29b2e1");

//}

//if (pagename == "Council") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').show();
//    $("#ProCounProUnique2 a").click();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProCounPro").addClass("active");
//    $("#ProCounPro").css("background", "#29b2e1");

//}

//if (pagename == "Commission") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').show();
//    $("#ProCommiProUnique2 a").click();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");

//    $("#ProCommiPro").addClass("active");
//    $("#ProCommiPro").css("background", "#29b2e1");

//}

//if (pagename == "VowsRemewal") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').show();
//    $("#ProVowsProUnique2 a").click();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProVowsPro").addClass("active");
//    $("#ProVowsPro").css("background", "#29b2e1");

//}

//if (pagename == "H-VisitAndLive") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').show();
//    $("#ProHVisitProUnique2 a").click();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProHVisitPro").addClass("active");
//    $("#ProHVisitPro").css("background", "#29b2e1");

//}

//if (pagename == "Transfer") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').show();
//    $("#ProTransProUnique2 a").click();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProTransPro").addClass("active");
//    $("#ProTransPro").css("background", "#29b2e1");

//}

//if (pagename == "Community") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').show();
//    $("#ProComProUnique2 a").click();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");

//    $("#ProComPro").addClass("active");
//    $("#ProComPro").css("background", "#29b2e1");

//}

//if (pagename == "Institution") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').show();
//    $("#ProInstProUnique2 a").click();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProInstPro").addClass("active");
//    $("#ProInstPro").css("background", "#29b2e1");

//}

//if (pagename == "Society") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').show();
//    $("#ProSocProUnique2 a").click();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProSocPro").addClass("active");
//    $("#ProSocPro").css("background", "#29b2e1");

//}

//if (pagename == "Trust") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').show();
//    $("#ProTrustProUnique2 a").click();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//}

//if (pagename == "Staff") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').show();
//    $("#ProStaffProUnique2 a").click();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProStaffPro").addClass("active");
//    $("#ProStaffPro").css("background", "#29b2e1");

//}

//if (pagename == "CouncilCount") {
//    $(".nav-tabs").find('#ProOffMeetProUnique2').hide();
//    $(".nav-tabs").find('#ProCounProUnique2').hide();
//    $(".nav-tabs").find('#ProCommiProUnique2').hide();
//    $(".nav-tabs").find('#ProVowsProUnique2').hide();
//    $(".nav-tabs").find('#ProHVisitProUnique2').hide();
//    $(".nav-tabs").find('#ProTransProUnique2').hide();
//    $(".nav-tabs").find('#ProComProUnique2').hide();
//    $(".nav-tabs").find('#ProInstProUnique2').hide();
//    $(".nav-tabs").find('#ProSocProUnique2').hide();
//    $(".nav-tabs").find('#ProTrustProUnique2').hide();
//    $(".nav-tabs").find('#ProStaffProUnique2').hide();
//    $(".nav-tabs").find('#ProCouncilCountProUnique2').show();
//    $("#ProCouncilCountProUnique2 a").click();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").addClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ProvinceOpen div").addClass("active");
//    $("#ProCouncilCountPro").addClass("active");
//    $("#ProCouncilCountPro").css("background", "#29b2e1");

//}

////Member
//if (baseUrl.includes("member")) {
//    $.cookie("TopActiveMenu", 'Member');
//    //alert("dd"+pagename)
//    $.cookie("TopActiveSubMenu", pagename);
//}
//if (baseUrl.includes("memeber")) {

//    $(".nav-tabs").find('#TotalRegistration').show();
//    $("#TotalRegistration a").click();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Member2") {
//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').show();
//    $("#TotalMember a").click();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Candidates2") {
//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();

//    $(".nav-tabs").find('#TotalEnterToNov').show();
//    $("#TotalEnterToNov a").click();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Novititate2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').show();
//    $("#TotalNovandPP a").click();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Profession2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $("#TotalOrdination a").click();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "TemporaryVows2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').show();
//    $("#TotalTemporary a").click();
//    $(".nav-tabs").find('#TotalOrdinations').hide();

//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Ordinations2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').show();
//    $("#TotalOrdinations a").click();

//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Death2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();

//    $(".nav-tabs").find('#TotalDeath').hide();
//    $("#TotalDeath a").click();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Departed2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();

//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').show();
//    $("#TotalDepart a").click();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "VowsRenewal2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $("#TotalVowsRenewal a").click();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "GeneralateFileNo") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $("#GeneralateFileNo a").click();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

//if (pagename == "Archive2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#GeneralateFileNo').hide();
//    $("#TotalArchive a").click();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}


//if (pagename == "Archive2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#GeneralateFileNo').hide();
//    $("#TotalArchive a").click();
//    $(".nav-tabs").find('#TotalAppointment').hide();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}


//if (pagename == "Archive2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').show();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();
//    $(".nav-tabs").find('#GeneralateFileNo').hide();
//    $(".nav-tabs").find('#TotalArchive').hide();
//    $("#TotalAppointment a").click();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#MembersOpen a").addClass("active");

//}

////Community
//if (baseUrl.includes("Community")) {
//    $.cookie("TopActiveMenu", 'Community');
//    $.cookie("TopActiveSubMenu", pagename);
//}
//if (pagename == "CongDetail2") {

//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();

//    $(".nav-tabs").find('#TotalMeetingComm').show();
//    $("#TotalMeetingComm a").click();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").addClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#CommunityOpen a").addClass("active");

//}
////Institution
//if (baseUrl.includes("Institution")) {
//    $.cookie("TopActiveMenu", 'Institution');
//    $.cookie("TopActiveSubMenu", pagename);
//}
//if (baseUrl.includes("Institution")) {
//    $(".nav-tabs").find('#TotalRegistration').hide();
//    $(".nav-tabs").find('#TotalMember').hide();
//    $(".nav-tabs").find('#TotalEnterToNov').hide();
//    $(".nav-tabs").find('#TotalNovandPP').hide();
//    $(".nav-tabs").find('#TotalOrdination').hide();
//    $(".nav-tabs").find('#TotalTemporary').hide();
//    $(".nav-tabs").find('#TotalOrdinations').hide();
//    $(".nav-tabs").find('#TotalDeath').hide();
//    $(".nav-tabs").find('#TotalDepart').hide();
//    $(".nav-tabs").find('#TotalVowsRenewal').hide();

//    $(".nav-tabs").find('#TotalMeetingComm').hide();
//    $(".nav-tabs").find('#TotalMeetingInst').show();

//    $("#TotalMeetingInst a").click();

//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#InstitutionOpen div").addClass("active");
//    $("#InstitutionOpen a").addClass("active");

//}
////Report
//if (pagename == "MemberReport" || pagename == "SocInsCommPage" || pagename == "Appointment" || pagename == "AllProvinceData" || pagename == "AllProvinceReports"
//    || pagename == "SaprateProData" || pagename == "DirectoryData" || pagename == "Directory2") {
//    $.cookie("TopActiveMenu", 'Report');
//    $.cookie("TopActiveSubMenu", pagename);
//}
//if (pagename == "MemberReport") {

//    $(".nav-tabs").find('#MemberReport').show();
//    $("#MemberReport a").click();
//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').hide();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').hide();
//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "SocInsCommPage") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').show();
//    $("#InstitutionReport a").click();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').hide();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').hide();
//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "Appointment") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').show();
//    $("#AppointmentSGStatistics a").click();
//    $(".nav-tabs").find('#ProvinceDataReports').show();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').hide();
//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "AllProvinceData") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').show();
//    $("#ProvinceDataReports a").click();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').hide();
//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "AllProvinceReports") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').hide();
//    $(".nav-tabs").find('#ProvinceStatistics').show();
//    $("#ProvinceStatistics a").click();
//    $(".nav-tabs").find('#Prostatistics').hide();

//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "SaprateProData") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').hide();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').show();
//    $("#Prostatistics a").click();
//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "DirectoryData") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').hide();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').hide();
//    $(".nav-tabs").find('#ProvinceDirector').show();
//    $("#ProvinceDirector a").click();
//    $(".nav-tabs").find('#SGDirectory').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

//if (pagename == "Directory2") {

//    $(".nav-tabs").find('#MemberReport').hide();

//    $(".nav-tabs").find('#InstitutionReport').hide();
//    $(".nav-tabs").find('#AppointmentSGStatistics').hide();
//    $(".nav-tabs").find('#ProvinceDataReports').hide();
//    $(".nav-tabs").find('#ProvinceStatistics').hide();
//    $(".nav-tabs").find('#Prostatistics').hide();
//    $(".nav-tabs").find('#ProvinceDirector').hide();
//    $(".nav-tabs").find('#SGDirectory').show();
//    $("#SGDirectory a").click();



//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").addClass("active");
//    $("#UtilitiesOpen div").removeClass("active");
//    $("#ReportsOpen a").addClass("active");

//}

////Utilites
//if (pagename == "DataItem" || pagename == "GetBackupFiles" || pagename == "RolePermission" || pagename == "ChangesPassword2" || pagename == "ChangePassword"
//    || pagename == "MultiLanguage" || pagename == "Utilities") {
//    $.cookie("TopActiveMenu", 'Utilites');
//    $.cookie("TopActiveSubMenu", pagename);
//}

//if (pagename == "DataItem") {

//    $(".nav-tabs").find('#DataList').show();
//    $("#DataList a").click();
//    $(".nav-tabs").find('#Backup').hide();
//    $(".nav-tabs").find('#Permissions').hide();
//    $(".nav-tabs").find('#Creatingthepassword').hide();
//    $(".nav-tabs").find('#Changingpassword').hide();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#ImportExcelsheet').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}

//if (pagename == "GetBackupFiles") {

//    $(".nav-tabs").find('#DataList').hide();

//    $(".nav-tabs").find('#Backup').show();
//    $("#Backup a").click();
//    $(".nav-tabs").find('#Permissions').hide();
//    $(".nav-tabs").find('#Creatingthepassword').hide();
//    $(".nav-tabs").find('#Changingpassword').hide();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#ImportExcelsheet').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}

//if (pagename == "RolePermission") {

//    $(".nav-tabs").find('#DataList').hide();

//    $(".nav-tabs").find('#Backup').hide();

//    $(".nav-tabs").find('#Permissions').show();
//    $("#Permissions a").click();
//    $(".nav-tabs").find('#Creatingthepassword').hide();
//    $(".nav-tabs").find('#Changingpassword').hide();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#ImportExcelsheet').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}

//if (pagename == "ChangesPassword2") {

//    $(".nav-tabs").find('#DataList').hide();
//    $(".nav-tabs").find('#Backup').hide();
//    $(".nav-tabs").find('#Permissions').hide();
//    $(".nav-tabs").find('#Creatingthepassword').show();
//    $("#Creatingthepassword a").click();
//    $(".nav-tabs").find('#Changingpassword').hide();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#ImportExcelsheet').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}

//if (pagename == "ChangePassword") {

//    $(".nav-tabs").find('#DataList').hide();
//    $(".nav-tabs").find('#Backup').hide();
//    $(".nav-tabs").find('#Permissions').hide();
//    $(".nav-tabs").find('#Creatingthepassword').hide();
//    $(".nav-tabs").find('#Changingpassword').show();
//    $("#Changingpassword a").click();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#ImportExcelsheet').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}

//if (pagename == "MultiLanguage") {

//    $(".nav-tabs").find('#DataList').hide();
//    $(".nav-tabs").find('#Backup').hide();
//    $(".nav-tabs").find('#Permissions').hide();
//    $(".nav-tabs").find('#Creatingthepassword').hide();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#MultipleLanguage').show();
//    $("#MultipleLanguage a").click();
//    $(".nav-tabs").find('#ImportExcelsheet').hide();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}

//if (pagename == "Utilities") {

//    $(".nav-tabs").find('#DataList').hide();
//    $(".nav-tabs").find('#Backup').hide();
//    $(".nav-tabs").find('#Permissions').hide();
//    $(".nav-tabs").find('#Creatingthepassword').hide();
//    $(".nav-tabs").find('#MultipleLanguage').hide();
//    $(".nav-tabs").find('#Changingpassword').hide();
//    $(".nav-tabs").find('#ImportExcelsheet').show();
//    $("#ImportExcelsheet a").click();


//    $("li a").removeClass("active");
//    $("#ProvinceOpen a").removeClass("active");
//    $("#CongregationOpen div").removeClass("active");
//    $("#MembersOpen div").removeClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").addClass("active");
//    $("#UtilitiesOpen a").addClass("active");

//}


////////////////////////////////////////Active tabs ////////////////////////////
////var pageURL = $(location).attr("href");
////if (pageURL.includes("ProvinceList2")) {

////    $("#CongregationOpen a").removeClass("active");
////    // add class to the one we clicked
////    $("#ProvinceOpen a").addClass("active");
////}



//var cookieValue = $.cookie("TopActiveMenu");
//if (cookieValue == "Member") {
//    $("#CongregationOpen div").removeClass("active");
//    $("#CongregationOpen a").removeClass("active");
//    $("#MembersOpen a").addClass("active");
//    $("#MembersOpen div").addClass("active");
//    $("#CommunityOpen div").removeClass("active");
//    $("#InstitutionOpen div").removeClass("active");
//    $("#ReportsOpen div").removeClass("active");
//    $("#UtilitiesOpen div").removeClass("active");

//    var pagename1 = $.cookie("TopActiveSubMenu");
//    if (pagename1 == "Registration2")
//        $("#TotalRegistration").css("background", "#29b2e1");

//    if (pagename1 == "Member2")
//        $("#TotalMember").css("background", "#29b2e1");

//    if (pagename1 == "Candidates2")
//        $("#TotalEnterToNov").css("background", "#29b2e1");

//    if (pagename1 == "Novititate2")
//        $("#TotalNovandPP").css("background", "#29b2e1");

//    if (pagename1 == "Profession2")
//        $("#TotalOrdination").css("background", "#29b2e1");


//    if (pagename1 == "TemporaryVows2")
//        $("#TotalTemporary").css("background", "#29b2e1");

//    if (pagename1 == "Ordinations2")
//        $("#TotalOrdinations").css("background", "#29b2e1");

//    if (pagename1 == "Death2")
//        $("#TotalDeath").css("background", "#29b2e1");

//    if (pagename1 == "Departed2")
//        $("#TotalDepart").css("background", "#29b2e1");

//    if (pagename1 == "VowsRenewal2")
//        $("#TotalVowsRenewal").css("background", "#29b2e1");

//    if (pagename1 == "GeneralateFileNo")
//        $("#GeneralateFileNo").css("background", "#29b2e1");

//    if (pagename1 == "Archive2")
//        $("#TotalArchive").css("background", "#29b2e1");
//    if (pagename1 == "Appointment2")
//        $("#TotalAppointment").css("background", "#29b2e1");
    

//}

    $('.site-nav > li').on('click', function () {
        $('.site-nav > li > a').removeClass('active');
        $('.site-nav > li .bottom_menu').removeClass('active');
        if ($(this).attr('id') != 'CommunityOpen' && $(this).attr('id') != 'InstitutionOpen') {
            $(this).find('a').addClass('active');
            $(this).find('a').next().addClass('active');
        }
    })



var baseUrl = (window.location).href; 
$('.bottom_menu > ul > li > a').each(function () {
    var href = $(this).attr('href');

    if (baseUrl.includes(href)) {
        $('.site-nav > li > a').removeClass('active');
        $('.site-nav > li .bottom_menu').removeClass('active');

        $(this).addClass('active');
        $(this).parent().css("background", "#29b2e1");
        $(this).parent().parents('li').children().addClass('active')
    }
})