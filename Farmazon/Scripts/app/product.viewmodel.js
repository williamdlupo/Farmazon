function productViewModel(app, dataModel) {
    var self = this;
    var tempProduct = {
        ProductID: 12,
        ProductName: "Apples",
        ProductImageURL: "https://via.placeholder.com/150",
        FarmerName: "Joe Bro Farmer Hoe",
        Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae nisi sed lectus sodales vestibulum. Cras eu leo quis nulla.",
        ReviewCount: 2400,
        ReviewText: function () { return this.ReviewCount + ' Reviews'; },
        ReviewStars: 5,
        Price: "$5.00"
    }

    this.save = function () {
        var request = $.ajax({
            url: "../../Product/FillInventory",
            method: "POST",
            data: {
                ItemId: self.productID,
                Quantity: self.quantity,
                Price: self.price,
                ProductName: self.productName,
                PhotoLocation: self.productImageURL,
                Description: self.description,
                ReviewCount: 100,
                ReviewStars: 5
            },
            dataType: "JSON",
            complete: self.closeModal.bind(self)
        });
    }

   

    // Get the modal
    this.modal = document.getElementById('productModal');

    // When the user clicks the button, open the modal 
    this.openModal = function (item, event) {
        self.setModal(item);
        self.modal.style.display = "block";
    }

    // When the user clicks on <span> (x), close the modal
    this.closeModal = function () {
        self.modal.style.display = "none";
        self.setModal();
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == self.modal) {
            self.modal.style.display = "none";
            self.setModal();
        }
    }

    this.setModal = function (item) {
        item = item || {};
        self.productID(item.ItemId ? item.ItemId : null);
        self.productName(item.ProductName ? item.ProductName : "");
        self.price(item.Price ? item.Price : "");
        self.quantity(item.Quantity ? item.Quantity : "");
        self.description(item.Description ? item.Description : "");
        self.productImageURL(item.ProductImageURL ? item.ProductImageURL : "");
    }

    this.productName = ko.observable();
    this.price = ko.observable();
    this.quantity = ko.observable();
    this.description = ko.observable();
    this.productImageURL = ko.observable();
    this.productID = ko.observable();

    this.products = ko.observableArray();

    this.products().push(tempProduct);
    this.products().push(tempProduct);
    this.products().push(tempProduct);
    this.products().push(tempProduct);
    this.products().push(tempProduct);

    return self;
}

app.addViewModel({
    name: "Product",
    bindingMemberName: "product",
    factory: productViewModel
});
