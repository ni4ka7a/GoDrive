(function () {
    var percentage = parseFloat($("#currentProgress").val());
    var circle = new ProgressBar.Circle('#progress-container', {
        color: 'white',
        text: {
            value: '0'
        },
        strokeWidth: 6,
        fill: '#311b92',
        trailWidth: 1,
        duration: 1500,
        step: function (state, bar) {
            bar.setText((bar.value() * 100).toFixed(0) + '%');
        }
    });

    circle.animate(1, function () {
        circle.animate(percentage);
    })

})();