var Cart = {
    Get: function () {
        var productID = "";
        if (localStorage.getItem("arrProductID") != null) {
            productID = localStorage.getItem("arrProductID");
        }
        else {
            localStorage.setItem("arrProductID", "[]");
            productID = localStorage.getItem("arrProductID");
        }
        var arr = JSON.parse(productID);
        return arr;
    },

    Set: function (arr) {
        var jsonProductID = JSON.stringify(arr);
        localStorage.setItem("arrProductID", jsonProductID);
    },

    AddItem: function (id, quantity) {
        // Lấy mảng cũ ra từ local
        var arr = Cart.Get();

        // Check exist
        var objIncIndex = arr.findIndex(obj => obj.ID === id);
        if(objIncIndex !== -1){
            alert('Sản phẩm đã có trong giỏ hàng')

            //$.alert({
            //    title: "",
            //    content: ""
            //});
            return;
        }

        // Thêm vào
        var newID = {
            ID: id,
            Quantity: quantity
        }
        arr.push(newID);

        // Set lại
        Cart.Set(arr);
        alert('Đã thêm sản phẩm vào giỏ hàng')
        Cart.ViewShopping();
    },

    Remove: function(id){
        var stogre = Cart.Get();
        var newCart = [];
        $.each(stogre, function(index, item){
            if(parseInt(item.ID) !== id){
                newCart.push(item);
            }
        });
        Cart.Set(newCart);
        $(".row_" + id).remove();
    },

    ChangQuantity: function(id, quantity){
        var stogre = Cart.Get();
        $.each(stogre, function(index, item){
            if(parseInt(item.ID) === id){
                item.Quantity = quantity;
            }
        });
        Cart.Set(stogre);
        Cart.ViewShopping();
    },

    ViewShopping: function(){
        var cartItems = Cart.Get();
        var newArray = [];
        $.each(cartItems, function(index, item) {
            var newID = {
                MaSanPham: item.ID,
                SoLuong: item.Quantity
            }
            newArray.push(newID);
        })

        var jsonData = {
            lstProduct: newArray
        }
        $.ajax({
            url: "/cart/loadproduct",
            type: "POST",
            data: jsonData,
            dataType: "html",
            success: function(data){
                $("#cart-shopping").empty();
                $("#cart-shopping").append(data);
            }
        });
    }
}