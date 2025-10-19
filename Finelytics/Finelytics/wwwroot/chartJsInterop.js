window.chartJsInterop = {
    instances: {},

    
    createLineChart: function (canvasId, config) {
        const ctx = document.getElementById(canvasId).getContext('2d');

        const chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: config.labels,
                datasets: [{
                    label: config.datasetLabel,
                    data: config.data,
                    borderColor: config.borderColor || 'rgb(75, 192, 192)',
                    backgroundColor: config.backgroundColor || 'rgba(75, 192, 192, 0.1)',
                    borderWidth: 2,
                    tension: 0.1,
                    fill: true
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    title: {
                        display: true,
                        text: config.title || 'Chart'
                    },
                    legend: {
                        display: config.showLegend !== false
                    }
                },
                scales: {
                    y: {
                        beginAtZero: config.beginAtZero || false
                    }
                }
            }
        });

        this.instances[canvasId] = chart;
        return true;
    },

    
    createFinancialChart: function (canvasId, financialData) {
        const ctx = document.getElementById(canvasId).getContext('2d');

        const chart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: financialData.labels,
                datasets: [{
                    label: 'Price',
                    data: financialData.data,
                    backgroundColor: function (context) {
                        const item = financialData.data[context.dataIndex];
                        return item.c >= item.o ? 'rgba(0, 255, 0, 0.7)' : 'rgba(255, 0, 0, 0.7)';
                    },
                    borderColor: function (context) {
                        const item = financialData.data[context.dataIndex];
                        return item.c >= item.o ? 'rgb(0, 200, 0)' : 'rgb(200, 0, 0)';
                    },
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    title: {
                        display: true,
                        text: 'Financial Chart'
                    },
                    tooltip: {
                        callbacks: {
                            label: function (context) {
                                const item = context.raw;
                                return [
                                    `Open: ${item.o}`,
                                    `High: ${item.h}`,
                                    `Low: ${item.l}`,
                                    `Close: ${item.c}`
                                ];
                            }
                        }
                    }
                },
                scales: {
                    y: {
                        beginAtZero: false
                    }
                }
            }
        });

        this.instances[canvasId] = chart;
        return true;
    },

    
    updateChartData: function (canvasId, newData) {
        const chart = this.instances[canvasId];
        if (chart) {
            chart.data.labels = newData.labels;
            chart.data.datasets[0].data = newData.data;
            chart.update();
            return true;
        }
        return false;
    },

   
    destroyChart: function (canvasId) {
        const chart = this.instances[canvasId];
        if (chart) {
            chart.destroy();
            delete this.instances[canvasId];
        }
    }
};