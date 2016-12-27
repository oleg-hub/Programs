function showError(container, errorMessage) {
    container.className = 'error';
    var msgElem = document.createElement('span');
    msgElem.className = "error-message";
    msgElem.innerHTML = errorMessage;
    container.appendChild(msgElem);
}

function resetError(container) {
    container.className = '';
    if (container.lastChild.className == "error-message") {
        container.removeChild(container.lastChild);
    }
}

function validatetext(form) {
    var elems = form.elements;

    resetError(elems.name.parentNode);
    if (!elems.name.value) {
    	showError(elems.name.parentNode, document.getElementById('Resource_EmptyName').value);
    }
    resetError(elems.commentText.parentNode);
    if (!elems.commentText.value) {
    	showError(elems.commentText.parentNode, document.getElementById('Resource_EmptyMessage').value);
    }
}