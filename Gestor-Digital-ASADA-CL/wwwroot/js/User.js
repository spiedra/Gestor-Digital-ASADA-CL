const putUserOnEditModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    const currentJobName = row.cells[5].textContent;
    const selectJobs = $('#selectJobsEditModal');

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
};

const putRolesOnAddModal = () => {
    const selectJobsNamesAddModal = $("#selectJobsAddModal");

    $.ajax({
        url: '/User/GetRolesByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            selectJobsNamesAddModal.empty();
            selectJobsNamesAddModal.prepend('<option class="select_opcion" value="" selected>Seleccione algún puesto</option>');
            response.forEach(element => {
                selectJobsNamesAddModal.append('<option class="select_opcion">' + element.tipoRole + '</option>');
            });
        }
    });
};

const putUserFullNameOnDeleteModal = (buttonContext) => {
    const msgContainerDeleteModal = $('#msgContainerDeleteModal');
    row = buttonContext.parentNode.parentNode;

    msgContainerDeleteModal.empty();
    msgContainerDeleteModal.append('El usuario <p class="fw-bold d-inline">' + row.cells[1].textContent + ' ' + row.cells[2].textContent + '</p> va a ser borrado permanentemente del sistema')
};