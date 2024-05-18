$(document).ready(function () {
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var Tquantity = $('#quantity_value1').val();
        if (Tquantity !== '') {
            quantity = parseInt(Tquantity);
        }
        $.ajax({
            url: '/Cart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout-item').html(rs.Count);
                    alert(rs.msg);
                    ShowCount();
                }
            }
        });
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = $('#Quantiy_' + id).val();
        Update(id, quantity);
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm("Bạn có muốn xóa sản phẩm này không?");
        if (conf == true) {
            $.ajax({
                url: '/Cart/Delete/' +id,
                type: 'POST',
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout-item').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });
});

function ShowCount() {
    $.ajax({
        url: '/Cart/ShowCount',
        type: 'GET',
        success: function (rs) {
            if (rs.Success) {
                $('#checkout-item').text(rs.Count);
            }
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/Cart/Partial_ItemCart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}

function Update(id, quantity) {
    $.ajax({
        url: '/Cart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}
