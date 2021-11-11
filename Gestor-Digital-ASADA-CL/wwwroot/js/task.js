var idTask;
var userId;

const getTasksByUserId = (buttonContext) => {
    userId = $(buttonContext).val();
    changeUserNameOfLabel($(buttonContext).attr("name"), userId);
    setTasksOnTbodyTask();
};

const changeUserNameOfLabel = (userFullName, userId) => {
    var tagUserFullName = $('#tagUserFullName');
    tagUserFullName.empty();
    tagUserFullName.attr("userId", userId);
    tagUserFullName.append("Usuario: " + userFullName);
};

const addTask = () => {
    var userId = $('#tagUserFullName').attr('userId');
    if ($("#formAddTask").valid()) {
        if (userId != null) {
            $.ajax({
                url: '/Task/Create',
                type: 'post',
                data: {
                    "UserId": userId,
                    "Title": $('#inputTitle').val(),
                    "Details": $('#inputDetail').val(),
                },
                dataType: 'json',
                success: function (response) {
                    setTasksOnTbodyTask();
                    $('#addModal').modal('hide');
                    createModalResponse2(response);
                }
            });
        } else {
            $('#addModal').modal('hide');
            createModalResponse2("Usuario no seleccionado. Intentelo de nuevo");
        }
    }
};

const putTaskOnEditModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    idTask = row.cells[0].textContent;

    $("#inputTitleEdit").val(row.cells[1].textContent);
    $("#inputDetailEdit").val(row.cells[2].textContent);
};

const updateTaskInformation = () => {
    if ($("#formEditTask").valid()) {
        $.ajax({
            url: '/Task/Edit',
            type: 'post',
            data: {
                "IdTask": idTask,
                "UserId": userId,
                "Title": $('#inputTitleEdit').val(),
                "Details": $('#inputDetailEdit').val(),
            },
            dataType: 'json',
            success: function (response) {
                setTasksOnTbodyTask();
                $('#editModal').modal('hide');
                createModalResponse2(response);
            }
        });
    }
};

const getIdTaskDelete = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    idTask = row.cells[0].textContent;
};

const deleteTask = () => {
    $.ajax({
        url: '/Task/Delete',
        type: 'post',
        data: {
            "IdTask": idTask
        },
        dataType: 'json',
        success: function (response) {
            $('#deleteModal').modal('hide');
            setTasksOnTbodyTask();
            createModalResponse2(response);
        }
    });
};

const setTasksOnTbodyTask = () => {
    var tbodyTable = $('#tbodyTask');

    $.ajax({
        url: '/Task/GetTasksByUserId',
        type: 'get',
        data: {
            "UserId": userId
        },
        dataType: 'json',
        success: function (response) {
            tbodyTable.empty();
            if (response.length != 0) {
                $(".toast").toast('hide');
                response.forEach(element => {
                    tbodyTable.append($('<tr>')
                        .append($('<td>').append(element['idTarea']))
                        .append($('<td>').append(element['titulo']))
                        .append($('<td>').append(element['detalles']))
                        .append($('<td>').append(
                            $('<button class="btn btn-primary btn-sm my-1 me-1 my-xl-0" data-bs-toggle="modal" data-bs-target="#editModal" onClick="putTaskOnEditModal(this); return false;">'
                                + 'Modificar <img src="/assets/edit_white_18dp.svg" alt="Icono eliminar usuario" class= "my-1"/></button>'
                            )).append($('<button class="btn btn-danger btn-sm my-1 my-xl-0" data-bs-toggle="modal" data-bs-target="#deleteModal" onClick="getIdTaskDelete(this); return false;">'
                                + 'Eliminar <img src="/assets/delete_white_18dp.svg" alt="Icono eliminar usuario" class="my-1" /></button>'
                            )))
                    )
                });
            } else {
                $(".toast").toast('show');
            }
        }
    });
};