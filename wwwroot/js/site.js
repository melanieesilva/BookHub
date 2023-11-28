var url = window.location.pathname;
var splitUrl = url.split('/')
var area = splitUrl.pop()

switch (area) {
    case "Login":
        let row = document.querySelector(".row")
        let column = row.querySelector(".col-md-6")
        column.classList.add("invisible")
        break;
    case "Register":
        //Editando textos da Criação de Conta
        const btnSubmit = document.getElementById("registerSubmit")
        const form = document.getElementById("registerForm")
        const titleForm = form.querySelector("h2")
        const labelPwd = form.querySelector("label[for='Input_Password']");
        const labelConfirm = form.querySelector("label[for='Input_ConfirmPassword']")
        let rowR = document.querySelector(".row")
        let columnR = rowR.querySelector(".col-md-6")

        columnR.classList.add("invisible")
        titleForm.innerHTML = "Crie sua conta"
        btnSubmit.innerHTML = "Criar Conta"
        labelPwd.innerHTML = "Senha"
        labelConfirm.innerHTML = "Confirme a senha"
        break;
    case "Create":
        // let inputData = document.getElementById("dataInput")
        // var dataAtual = new Date()
        // var dataFormat = dataAtual.toLocaleDateString('pt-BR', { day: '2-digit', month: '2-digit', year: 'numeric' })
        // inputData.value = dataFormat
        // console.log(inputData.value)
        break;
    case "Anotacoes":

        break;

    default:
        break;
}


const cardNote = document.querySelectorAll("#note")
cardNote.forEach(card => {
    let dataCard = card.getAttribute("data-cor")
    console.log(dataCard)
    card.style.backgroundColor = `${dataCard}`
})



function openModal() {

    let modalCreate = new bootstrap.Modal(document.getElementById('modalCreate'))
    modalCreate.show()
}


function select(el) {
    const coresSelecionadas = document.querySelectorAll('.cor')
    const inputCor = document.getElementById('inputCor')
    let modal = document.getElementById("modalContent")
    let data = el.getAttribute("data-backCor")

    coresSelecionadas.forEach(cor => {
        cor.classList.remove("bordaCor")
    })

    el.classList.toggle("bordaCor")
    modal.style.backgroundColor = data
    inputCor.value = data

}