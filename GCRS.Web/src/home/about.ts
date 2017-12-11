import ChartViewer from "src/shared/chart-viewer";

export default class About {

    private chartViewer: ChartViewer;

    constructor(params?: { [key: string]: string }, queryString?: { [key: string]: string }) {

        const provinces: { [key: string]: IChartData } = {
            habana: {
                labels: ["Playa", "Habana Vieja", "Centro Habana", "Plaza"],
                data: [12, 19, 3, 5],
            },
            matanzas: {
                labels: ["Matanzas", "Varadero", "Cárdenas"],
                data: [7, 24, 11],
            },
            pinardelrio: {
                labels: ["Pinar del Río", "Viñales"],
                data: [5, 9],
            },
        };

        let data: IChartData;
        if (params != null && params.id != null) {
            data = provinces[params.id.toLowerCase()];
        } else {
            for (const key of Object.getOwnPropertyNames(provinces)) {
                if (data == null) {
                    data = provinces[key];
                } else {
                    data.labels = data.labels.concat(provinces[key].labels);
                    data.data = data.data.concat(provinces[key].data);
                }
            }
        }

        if (data == null) {
            return;
        }

        this.chartViewer = new ChartViewer("chart-viewer", {
            type: queryString == null || queryString.type == null ? "bar" : queryString.type,
            data: {
                labels: data.labels,
                datasets: [{
                    label: "# de Alquileres",
                    data: data.data,
                }],
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                        },
                    }],
                },
                elements: {
                    rectangle: {
                        backgroundColor: queryString == null || queryString.color == null
                            ? "gray" : queryString.color,
                    },
                    line: {
                        backgroundColor: queryString == null || queryString.color == null
                            ? "gray" : queryString.color,
                    },
                },
            },
        });
    }
}
