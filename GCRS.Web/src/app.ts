import About from "./home/about";
import Home from "./home/home";
import Router from "./shared/router";
import CreateRequest from "./offerRequest/createRequest";

const router = new Router({
    routes: [
        {
            path: ["", "home", "home/index"],
            component: Home,
        },
        {
            path: ["", "offerRequest", "offerRequest/createRequest"],
            component: CreateRequest,
        },
        {
            path: ["home/about/:id?"],
            component: About,
        },
    ],
});
router.start();
