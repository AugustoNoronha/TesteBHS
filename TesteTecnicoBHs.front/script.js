var baseUrl = "https://localhost:7249";

window.onload = function () {
    listarValidos()
}


function listarValidos() {
    let title = document.getElementById("titlepage")
    let tbody = document.getElementById("tbody")
    tbody.innerHTML = "<tbody><tbody/>"
    title.innerText = "Produtos Validos"

    $.getJSON(`${baseUrl}/Produto/ativos`, function (json_data) {

        json_data.data.map((e) => {
            console.log(e)

            let tr = tbody.insertRow();

            let td_id = tr.insertCell();
            let td_name = tr.insertCell();
            let td_status = tr.insertCell();

            td_id.innerText = e.id;
            td_name.innerText = e.name;
            td_status.innerHTML = `<div style="
                border-radius: 50%;
                background-color: green;
                height: 10px;
                width: 10px;
                "
                 ><div/>`
        });


    });

}

function listarTodos() {
    let title = document.getElementById("titlepage")
    let tbody = document.getElementById("tbody")
    tbody.innerHTML = "<tbody><tbody/>"
    title.innerText = "Todos os Produtos"

    $.getJSON(`${baseUrl}/Produto`, function (json_data) {

        json_data.data.map((e) => {
            console.log(e)

            let tr = tbody.insertRow();

            let td_id = tr.insertCell();
            let td_name = tr.insertCell();
            let td_status = tr.insertCell();

            td_id.innerText = e.id;
            td_name.innerText = e.name;

            e.status ? 
            td_status.innerHTML = `<div style="
                border-radius: 50%;
                background-color: green;
                height: 10px;
                width: 10px;
                "
                 ><div/>` 
                 :
                td_status.innerHTML = `<div style="
                 border-radius: 50%;
                 background-color: red;
                 height: 10px;
                 width: 10px;
                 "
                  ><div/>` 
        });


    });

}


