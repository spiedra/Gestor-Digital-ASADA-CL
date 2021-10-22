function putOnModalActivity(object) {
    var activity = object.parentNode;

    while (activity.id != "detalle") {
        activity = activity.previousSibling;
    }
    $("#taDetalleModificar").val(activity.textContent.trim());

   
    while (activity.id != "idBitacora") {
        activity = activity.previousSibling;
    }
    $("#idb").val(activity.textContent.slice(1));
}

function putOnModalDelete(object) {
    var activity = object.parentNode;

    while (activity.id != "idBitacora") {
        activity = activity.previousSibling;
    }

    $("#idDelete").val(activity.textContent.slice(1));
}