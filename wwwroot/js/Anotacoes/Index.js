function deleteConfirm(el) {

    let modalDelete = new bootstrap.Modal(document.getElementById('modalDelete'))
    modalDelete.show()

    let dataEl = el.getAttribute('data-IdAnotacao')
    let inputHidden = document.getElementById("IdLivroHidden")
    inputHidden.setAttribute("name","id")
    inputHidden.value = dataEl

    console.log(inputHidden)
}