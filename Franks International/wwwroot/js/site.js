// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function renderChart(data, labels) {
    var ctx = document.getElementById("myChart").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Historical Data',
                data: data,
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
            }]
        },
    });
}

$("#renderBtn").click(
    function () {
        data = [267035.92, 279144.06, 270418.97, 397370.5, 362751.8, 269145.09, 247442.57, 231280.43, 263462.06, 290873.21, 323884.38, 296369.43];
        labels = ["August", "September", "October", "November", "December", "January", "February", "March", "April", "May", "June", "July"];
        renderChart(data, labels);
    }
);