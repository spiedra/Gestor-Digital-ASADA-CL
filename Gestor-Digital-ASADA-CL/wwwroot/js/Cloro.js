function putCloroOnModal(button) {
    var row = button.parentNode.parentNode;
    var idUsuario = 0;
    var option = $('.sedit option:first-child')
    if (option.data('last') === undefined){
    } else {
        option.remove();
    }
    $("#inputIdCloro").val(row.cells[0].textContent);
    $("#inputDate").val(moment(new Date(row.cells[1].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#inputPercent").val(row.cells[2].textContent);
    $("#inputIdHouse").val(row.cells[3].textContent);
    $("#inputNameC").val(row.cells[4].textContent);
    //$("#inputNameE").each(function () {
    //    alert($(this).text() + $.trim(row.cells[5].textContent))
    //    if ($.trim($(this).text()) === $.trim(row.cells[5].textContent)) {

    //        idUsuario = $(this).attr('value');

    //    }
    //    //alert('opcion ' + $(this).text() + ' valor ' + $(this).attr('value'))
    //});
    //alert(idUsuario)
    //let $option = $('<option />', {
    //    text: 'Actual: ' + row.cells[5].textContent,
    //    value: idUsuario,
    //    data: {
    //        last: 1
    //    }
    //});
    //$('#inputNameE').prepend($option);
    //$('.sedit option[value="current"]').attr("selected", true);
    //$(".sedit option[value='fonta']").remove();
    $("#inputDetails").val(row.cells[6].textContent);
}