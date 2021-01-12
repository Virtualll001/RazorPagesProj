var dataTable; //TODO: není dořešené přepsání anglických popisků tlačítek a okolí tabulky která se načítá z externího zdroje

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/kucharka",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "jmeno", "width": "15%" },
            { "data": "ingredience", "width": "25%" },
            { "data": "recept", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {  //jestli je někde chyba, tak v pojmenovávání u Delete
                    return `<div class="text-center"> 
                        <a href="/ViewKuch/Upsert?id=${data}" class='btn btn-sm btn-success text-white' style='cursor:pointer; width:60px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-sm btn-danger text-white' style='cursor:pointer; width:60px;'
                            onclick=Delete('/api/kucharka?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Určitě si přejete záznam smazat?",
        text: "Tuto akci nelze vrátit!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}