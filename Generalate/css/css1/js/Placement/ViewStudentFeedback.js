$(document).ready(function () {
    var weburl = "";
    if (!weburl) weburl = window.location.href
    var array = weburl.split('/');
    var no = array[array.length - 1];
    var sRole = '<%= Session["role"] %>';
    LoadStudentFeedbackDetails(no)
    //GetAcademicDetailsView(no);
    //GetWorkExperience(no);
    //LoadInternshipDetails(no);
    //LoadDeclarationDetails(no);
    //GetSemmisterDetailsView(no);
    //GetSkillsView(no);
});



function LoadStudentFeedbackDetails(no) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Student.asmx/getFeedbackById",
        data: "{'id' : '" + no + "'}",
        dataType: "json",
        success: function (data) {
            $("#viewfeedback").append("<tr><td><b>Scholar Number</b><td>" + data.d[0].RegisterNumber + "</td><td><b>Feedback Date</b></td><td>" + data.d[0].FeedbackDate + "</td></tr>"
                                 + "<tr><td><b>Batch</b><td>" + data.d[0].Batch + "</td><td><b>Student Name</b></td><td>" + data.d[0].StudentName + "</td></tr>"
                                 + "<tr><td><b>Specialization</b><td>" + data.d[0].Specialization + "</td><td><b>Company Name</b></td><td>" + data.d[0].CompanyName + "</td></tr>"
                                 + "<tr><td><b>Designation</b><td>" + data.d[0].Designation + "</td><td><b>Profile Selected</b></td><td>" + data.d[0].ProfileSelected + "</td></tr>"
                                 + "<tr><td><b>Date of Joining</b><td>" + data.d[0].DateofJoining + "</td><td><b>Group Discussion Topic</b></td><td>" + data.d[0].GroupDiscussionTopic + "</td></tr>"
                                 + "<tr><td><b>Topics to be Prepared</b><td>" + data.d[0].TopicstobePrepared + "</td><td><b>Any gaps in the curriculum and the industry demand</b><td>" + data.d[0].GapsinCurriculam + "</td></tr>"
                                  + "<tr><td><b>Technical Skills</b><td>" + data.d[0].TechnicalSkills + "</td><td><b>Certificaitons</b><td>" + data.d[0].Certificaitons + "</td></tr>"
                                  + "<tr><td><b>Books Recommended</b><td>" + data.d[0].BooksRecommended + "</td><td><b>Your Valuable One Line Suggestion to succeed in the selection process</b><td>" + data.d[0].OnelineSuggesstion + "</td></tr>"
                                  + "<tr><td><b>Test appeared for<b></td><td colspan='3'>" + data.d[0].TestsAppeardFor + "</td></tr>"
                                   + "<tr><td><b> Group Discussion<b></td><td colspan='3'>" + data.d[0].GroupDiscussion + "</td></tr>"
                                   
                                  + "<tr><td><b>Interview<b></td><td colspan='3'>" + data.d[0].Inteveriw + "</td></tr>"
                                 + "<tr><td><b>Questions answered by you<b></td><td colspan='3'>" + data.d[0].AnsweredQuestion + "</td></tr>"
                                 + "<tr><td><b>Questions not answered by you<b></td><td colspan='3'>" + data.d[0].NotAnsweredQuestion + "</td></tr>"
                                 + "<tr><td><b>No of round<b></td><td colspan='3'>" + data.d[0].NoofInterviewRound + "</td></tr>");
                                




            //get Selection Detail

            

            


        },
        error: function (result) {
            alert("Error");
        }
    });
}







