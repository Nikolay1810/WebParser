function RegisterPageEvents(pageId, callback) {
    $(document).delegate('#' + pageId, "pageshow", callback);
};

function RegisterPageEventsLoad(pageId, callback) {
    $(document).delegate('#' + pageId, "pageload", callback);
};

RegisterPageEvents('Home', function () {
    $.getScript('Scripts/Home/HomeView.js', function () {

        if (typeof (homePage) == 'undefined') {
            homePage = new HomePage.HomeView({ viewName: 'Index', pageId: 'Home', viewInstanceVariableName: 'homePage' });
        }
        homePage.pageshow();
    });
});

RegisterPageEvents('List', function () {
    $.getScript('/Scripts/Home/ListView.js', function () {
        listPage = new ListPage.ListView({ viewName: 'List', pageId: 'List', viewInstanceVariableName: 'listPage' });
        listPage.pageshow();
    });
});

RegisterPageEvents('Product', function () {
    $.getScript('/Scripts/Product/ProductView.js', function () {
        productPage = new ProductPage.ProductView({ viewName: 'Product', pageId: 'Product', viewInstanceVariableName: 'productPage' });
        productPage.pageshow();
    });
});