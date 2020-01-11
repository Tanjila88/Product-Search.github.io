/// <reference path="jquery.signalR-2.3.0.min.js" />
/// <reference path="jquery-1.10.2.min.js" />

$(function () {  
    // Click on notification icon for show notification  
    $('span.noti').click(function () {
        $('span.noti').css("color", "lightgreen");  
        $('span.count').hide();  
        var count = 0;  
        count = parseInt($('span.count').html()) || 0;  
        count++;  
        // only load notification if not already loaded  
        if (count > 0) {  
            updateNotification();                         
        }  
        $('span.count', this).html(' ');  
    })  
 
    // update notification  
    function updateNotification() {  
        $('#notiContent').empty();  
        $('#notiContent').append($('<li>Loading...</li>'));  
        $.ajax({  
            type: 'GET',  
            url: '/home/GetNotifications',  
            success: function (response) {
                $('#notiContent').empty();
                if (response.length == 0) {
                    $('#notiContent').append($('<li>Currently You Have No New Notifications.</li>'));  
                }
                $.each(response, function (index, value) {
                    
                    var html;
                    html = '<li>' + value.text + '</li>';
                    $('#notiContent').append(html);  
                });  
            },  
            error: function (error) {  
                console.log(error);  
            }  
        })  
    }  
    // update notification count  
    $.ajax({
        url: '/Home/NotficationCount',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            $('.count').html(res);
        }
    })
})  