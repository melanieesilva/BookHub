const cardNote = document.querySelectorAll("#note")
cardNote.forEach(card => {
    let dataCard = card.getAttribute("data-cor")
    console.log(dataCard)
    card.style.backgroundColor = `${dataCard}`
})



var inputCor = document.getElementById('inputCor')

function select(el) {
    const coresSelecionadas = document.querySelectorAll('.cor')
    // let modal = document.getElementById("modalContent")
    let data = el.getAttribute("data-backCor")

    coresSelecionadas.forEach(cor => {
        cor.classList.remove("bordaCor")
    })

    el.classList.toggle("bordaCor")
    // modal.style.backgroundColor = data
    inputCor.value = data
    console.log(inputCor.value)
    document.querySelector("main").style.backgroundColor = data;
}