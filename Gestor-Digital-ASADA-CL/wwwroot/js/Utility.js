function createModalResponse(response) {
    $('#modalResponse').remove();
    $('#pageMain').append($('<div class="modal fade" id="modalResponse" tabindex="-1" aria-labelledby="modalResponse" aria-hidden="true">')
        .append($('<div class="modal-dialog">')
            .append($('<div  class="modal-content">')
                .append($('<div style="background-color: #6DC7F6;" class="modal-header">'))
                .append($('<h5 class="p-1 modal-title">Mensaje del sistema</h5> <hr></'))
                .append($('<div class="modal-body">').append('<div class="container"><p style="font-size: 20px">' + response + '</p></div>'))
                .append($('<div class="modal-footer">').append('<button type="button" style="background-color: #313436;" class="btn btn-primary" data-bs-dismiss="modal">Ok</button>'))))
    )
    $('#modalResponse').modal("show");
}

function createModalResponse2(response) {
    $('#modalResponse').remove();
    $('#pageMain').append($('<div class="modal fade" id="modalResponse" tabindex="-1" aria-labelledby="modalResponse" aria-hidden="true">')
        .append($('<div class="modal-dialog">')
            .append($('<div  class="modal-content">')
                .append($('<div class="modal-header">')
                    .append($('<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>')))
                .append($('<div class="modal-body">').append('<p class="h6">' + response + '</p>'))
                .append($('<div class="modal-footer">').append('<button type="button" class="btn btn-primary" data-bs-dismiss="modal">Aceptar</button>'))))
    )
    $('#modalResponse').modal("show");
}