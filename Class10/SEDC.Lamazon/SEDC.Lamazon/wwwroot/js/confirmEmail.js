document.addEventListener("DOMContentLoaded", function () {
    const inputs = document.querySelectorAll(".code-inputs input");

    inputs.forEach((input, index) => {
        input.addEventListener("keyup", function () {
            if (index < inputs.length - 1 && input.value) {
                inputs[index + 1].focus();
            }
        });

        input.addEventListener("paste", function (e) {
            let pasteData = e.clipboardData.getData('text');
            if (pasteData && pasteData.length === 6) {
                pasteData.split('').forEach((char, charIndex) => {
                    if (charIndex < 6) {
                        inputs[charIndex].value = char;
                    }
                });
                e.preventDefault();
            }
        });
    });
});