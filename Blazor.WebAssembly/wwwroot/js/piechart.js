window.renderPieChart = (canvasId, labels, data, titulo) => {
    if (typeof Chart === 'undefined') {
        console.error("Chart.js no está cargado.");
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
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: [
                    '#f97316', '#3b82f6', '#10b981', '#ef4444', '#8b5cf6', '#ec4899', '#facc15'
                ]
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
                    position: 'bottom'
                }
            }
        }
    });

    console.log("Gráfico de torta renderizado correctamente para:", canvasId);
};