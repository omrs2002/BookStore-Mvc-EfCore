$(function () {
    var l = abp.localization.getResource('BookStore');
    abp.log.debug('Index.js initialized!');
    
    $('.navbar-brand').html(l('BookStore'));
});