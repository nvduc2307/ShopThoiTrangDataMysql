document.addEventListener("DOMContentLoaded", function(event) {
    var formProductSubmit = document.forms["form-product-submit"];
    var btnDeleteProduct = $(".btn-delete-product");
    btnDeleteProduct.on("click", function(event) {
        event.preventDefault();
        var id = event.target.dataset.id;
        formProductSubmit.action = `/admin/products/delete/${id}`;
        formProductSubmit.submit();
    });
});