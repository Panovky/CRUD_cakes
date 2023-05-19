let btns_cancel = document.querySelectorAll('.btn-cancel');
btns_cancel.forEach((elem) => {
    elem.addEventListener('click', () => {
        let forms = document.querySelectorAll(".form");
        forms[0].style.display = "none";
        forms[1].style.display = "none";
        forms[2].style.display = "none";
    })
})

let btns_delete = document.querySelectorAll('.btn-open-form-delete');
btns_delete.forEach((elem) => {
    elem.addEventListener('click', (e) => {
        let form = document.querySelectorAll(".form")[0];
        form.style.display = "block";
        let btn_delete = document.querySelector('.btn-delete');
        btn_delete.id = Number(e.target.id);
    })
})

let btn_delete = document.querySelector('.btn-delete');
btn_delete.addEventListener('click', (e) => {
    let input = document.querySelector('#delete-id');
    input.value = Number(e.target.id);
})

let btns_create = document.querySelectorAll('.btn-open-form-create');
btns_create.forEach((elem) => {
    elem.addEventListener('click', (e) => {
        let form = document.querySelectorAll(".form")[2];
        form.style.display = "block";
    })
})

let btns_update = document.querySelectorAll('.btn-open-form-update');
btns_update.forEach((elem) => {
    elem.addEventListener('click', (e) => {
        let form = document.querySelectorAll(".form")[1];
        form.style.display = "block";
        
        let id = Number(e.target.id);

        document.querySelector('#update-id').value = id;
        document.querySelector('#update-name').value = document.querySelector(`#name-${id}`).textContent;
        document.querySelector('#update-brand').value = document.querySelector(`#brand-${id}`).textContent;
        document.querySelector('#update-weight').value = Number(document.querySelector(`#weight-${id}`).textContent.replace(' г',''));
        document.querySelector('#update-price').value = Number(document.querySelector(`#price-${id}`).textContent.replace(' руб.', ''));
        document.querySelector('#update-calories').value = Number(document.querySelector(`#calories-${id}`).textContent.replace(' ккал на 100 г', ''));

        if (document.querySelector(`#gluten-${id}`).textContent == "содержится") {
            document.querySelector('#update-gluten-true').checked = true;
            document.querySelector('#update-gluten-false').checked = false;
        }
        else {
            document.querySelector('#update-gluten-true').checked = false;
            document.querySelector('#update-gluten-false').checked = true;
        }  
    })
})

