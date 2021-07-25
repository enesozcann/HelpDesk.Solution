var ticketid = -1;
var modalCommentBodyId = "#ticket-details_body";

$(function () {
    $('#ticket-details').on('show.bs.modal', function (event) {
        ticketid = $(event.relatedTarget).attr('data-id')

        $(modalCommentBodyId).load("/Ticket/TicketDetails/" + ticketid);
    })
});

function doReplySave(btn, ticketid) {
    var text = $("#Content").val();
    if (text =="") {
        // yorumlar partial tekrar yüklenir..
        $(modalCommentBodyId).load("/Ticket/TicketDetails/" + ticketid);
        alert("Cevap boş geçilemez!");
    }
    $.ajax({
        method: "POST",
        url: "/Ticket/CreateReply/",
        data: { id: ticketid, content: text }
    }).done(function (data) {
        if (data.result) {
            // yorumlar partial tekrar yüklenir..
            $(modalCommentBodyId).load("/Ticket/TicketDetails/" + ticketid);
            alert("Cevap gönderildi.");
        }
        else {
            alert("Cevap gönderilemedi.");
        }
    }).fail(function () {
    });
}



function doTicketUpdate(btn,ticketid, id) {
    var button = $(btn);

    var stat = $("#Item2_Status option:selected").val();

    $.ajax({
        method: "POST",
        url: "/Ticket/TicketUpdate/",
        data: { status: stat, id: ticketid }
    }).done(function (data) {
        if (data.result) {
            // yorumlar partial tekrar yüklenir..
            $(modalCommentBodyId).load("/Ticket/TicketDetails/" + ticketid);
            alert("Durum güncellendi.");
        }
        else {
            alert("Durum güncellenemedi.");
        }
    }).fail(function () {
        alert("Sunucu ile bağlantı kurulamadı.");
        });
}

