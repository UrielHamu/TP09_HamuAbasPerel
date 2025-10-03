const palabraOriginal = (document.getElementById("palabraActual").value).toLowerCase()
    let progreso = []
    for (let i = 0; i < palabraOriginal.length; i++) {
        progreso.push("_")
}    
    let intentos = 0

    function actualizarVista(mensaje) {
        document.getElementById("palabra").innerText = progreso.join(" ")
        document.getElementById("intentos").value = intentos
        document.getElementById("mensaje").innerText = mensaje
    }

    function habilitarBotonFin() {
        const contenedor = document.getElementById("accionesFinales")
        contenedor.innerHTML = `<form method="post" action="/Home/finJuego">
                <input type="hidden" name="intentos" value="${intentos}">
                <button type="submit">Finalizar partida</button>
            </form>`
    }

    function arriesgarLetra() {
        const letraInput = document.getElementById("letra")
        let letra = letraInput.value.toLowerCase()
        if (!letra || letra.length !== 1) {
            actualizarVista("Ingresá una sola letra")
        }
        intentos++

        let correcto = false
        for (let i = 0; i < palabraOriginal.length; i++) {
            if (palabraOriginal[i] === letra) {
                progreso[i] = letra
                correcto = true
            }
        }

        if (correcto) {
            actualizarVista("Correcto! La letra " + letra + " está en la palabra.")
        } else {
            actualizarVista("La letra " + letra + " no está en la palabra.")
        }

        letraInput.value = ""

        if (!progreso.includes("_")) {
            alert("Felicitaciones! Adivinaste la palabra en " + intentos + " intentos")
            habilitarBotonFin()
        }
    }

    function intentar() {
        const intentoInput = document.getElementById("intento")
        let intento = intentoInput.value.toLowerCase()
        if (!intento) {
            actualizarVista("Ingrese una palabra.")
            return
        }
        intentos++
        if (intento == palabraOriginal) {
            progreso = palabraOriginal.split("")
            actualizarVista()
            alert("Felicitaciones! Adivinaste la palabra en " + intentos + " intentos")
            habilitarBotonFin()
        } else {
            alert("Incorrecto, la palabra era: " + palabraOriginal)
            habilitarBotonFin()
        }
    }