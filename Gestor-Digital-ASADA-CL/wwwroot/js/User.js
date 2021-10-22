const putUserOnModal = (button) => {
    row = button.parentNode.parentNode;
    const currentJobName = row.cells[5].textContent;
    const selectJobs = $('#selectJobs');

    $("#inputIdCard").val(row.cells[0].textContent);
    $("#inputName").val(row.cells[1].textContent);
    $("#inputLastName").val(row.cells[2].textContent);
    $("#inputUserName").val(row.cells[3].textContent);
    $("#inputPassword").val(row.cells[4].textContent);

    $.ajax({
        url: '/User/GetRolesByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            selectJobs.empty();
            response.forEach(element => {
                if (element.tipoRole === currentJobName) {
                    selectJobs.append('<option class="select_opcion" selected>' + element.tipoRole + '</option>');
                } else {
                    selectJobs.append('<option class="select_opcion">' + element.tipoRole + '</option>');
                }
            });
        }
    });
}