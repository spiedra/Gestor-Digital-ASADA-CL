////const { data } = require("jquery");

function putOnModal(button) {
    row = button.parentNode.parentNode;
    code = row.cells[0].textContent;
    name = row.cells[1].textContent;
    unit_value = row.cells[2].textContent;
    amount = row.cells[3].textContent;
    date_in = row.cells[4].textContent;
    description = row.cells[5].textContent;

    $("#codigo").val(code);
    $("#nombre").val(name);
    $("#valor").val(unit_value);
    $("#cantidad").val(amount);
    $("#fecha").val(date_in);
    //document.getElementById("fecha").value(new Date("07/03/2021 10:34"));
    $("#descripcion").text(description);
}

function putOnModalDelete(button) {
    row = button.parentNode.parentNode;
    code = row.cells[0].textContent;
    $("#productCode").val(code);
}

function putOnModalReport(button) {
    row = button.parentNode.parentNode;
    if (parseInt(row.cells[3].textContent) == 0) {
        createModalResponse("No hay cantidad disponible.");
    } else {
        code = row.cells[0].textContent;
        document.getElementById("productoSolicitado").innerHTML = "Toma de producto: " + row.cells[1].textContent;
        $("#productoS").val(code);
    }
}