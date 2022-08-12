const buttonsEdit = document.getElementsByClassName("edit");
const buttonsCancel = document.getElementsByClassName("cancel");

const canBeHiddenEdit = document.getElementsByClassName("can-be-hidden-edit");
const canBeHiddenText = document.getElementsByClassName("can-be-hidden-text");

for (let b of buttonsEdit) {
    b.onclick = onEdit(b.dataset.id);
}

function onEdit(id) {
    return () => {
        for (let el of buttonsEdit) {
            if (el.dataset.id == id) {
                el.classList.add("d-none");
            }
        }
        for (let el of canBeHiddenEdit) {
            if (el.dataset.id == id) {
                el.classList.remove("d-none");
            }
        }
        for (let el of canBeHiddenText) {
            if (el.dataset.id == id) {
                el.classList.add("d-none");
            }
        }
    }
}

for (let b of buttonsCancel) {
    b.onclick = onCancel(b.dataset.id);
}

function onCancel(id) {
    return () => {
        for (let el of buttonsEdit) {
            if (el.dataset.id == id) {
                el.classList.remove("d-none");
            }
        }
        for (let el of canBeHiddenEdit) {
            if (el.dataset.id == id) {
                el.classList.add("d-none");
            }
        }
        for (let el of canBeHiddenText) {
            if (el.dataset.id == id) {
                el.classList.remove("d-none");
            }
        }
    }
}