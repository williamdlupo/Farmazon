function HomeViewModel(app, dataModel) {
    var self = this;

    Sammy(function () {
        this.get('#home', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            $.ajax({
                method: 'get',
                url: app.dataModel.userInfoUrl,
                contentType: "application/json; charset=utf-8",
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: function (data) {
                }
            });
        });
        this.get('/', function () { this.app.runRoute('get', '#home'); });
    });

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

    this.clickAddCart = function (data) {
        alert(data.ProductID);
    }

    this.zipCode = ko.observable();

    this.zipCode.subscribe(function (data) { alert(data); });

    this.products = ko.observableArray();

    this.products().push(tempProduct);
    this.products().push(tempProduct);
    this.products().push(tempProduct);
    this.products().push(tempProduct);
    this.products().push(tempProduct);

    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
