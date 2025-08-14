window.goBack = () => {
    if (window.history.length > 1)
        window.history.back();
    else
        location.href = '/home';
};