window.renderBarChart = (canvasId, labels, data, titulo) => {
    if (typeof Chart === 'undefined') {
        console.error("Chart.js no está cargado. Verificá el script en index.html");
        return;
    }

    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error("No se encontró el canvas con id:", canvasId);
        return;
    }

    const ctx = canvas.getContext('2d');
    if (!ctx) return;

    if (window[canvasId + '_chart']) {
        try {
            window[canvasId + '_chart'].destroy();
        } catch (e) {
            console.warn(e);
        }
    }

    window[canvasId + '_chart'] = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Cantidad de complejos',
                data: data,
                backgroundColor: '#ee5801'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                title: {
                    display: true,
                    text: titulo
                },
                legend: {
                    display: false
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        stepSize: 1
                    }
                }
            }
        }
    });

    console.log("Gráfico renderizado correctamente para:", canvasId, labels, data);
};
