declare type MapLayerTypes = 'cuba' | 'landuse' | 'roads' | 'water' | 'waterways' | 'points';

interface ILatLon {
    Latitude: number;
    Longitude: number;
}

interface IChartData {
    labels: string[];
    data: number[];
}

declare module "ol/map" {
    export default ol.Map;
}

declare module "ol/view" {
    export default ol.View;
}

declare module "ol/layer/image" {
    export default ol.layer.Image;
}

declare module "ol/layer/vector" {
    export default ol.layer.Vector;
}

declare module "ol/source/imagewms" {
    export default ol.source.ImageWMS;
}

declare module "ol/source/vector" {
    export default ol.source.Vector;
}

declare module "ol/overlay" {
    export default ol.Overlay;
}

declare module "ol/mapbrowserevent" {
    export default ol.MapBrowserEvent;
}

declare module "ol/proj" {
    export default ol.proj;
}

declare module "ol/feature" {
    export default ol.Feature;
}

declare module "ol/style/style" {
    export default ol.style.Style;
}

declare module "ol/style/stroke" {
    export default ol.style.Stroke;
}

declare module "ol/geom/linestring" {
    export default ol.geom.LineString;
}
