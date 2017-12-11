import About from "./home/about";
import Home from "./home/home";
import Router from "./shared/router";

const router = new Router({
    routes: [
        {
            path: ["", "home", "home/index"],
            component: Home,
        },
        {
            path: ["home/about/:id?"],
            component: About,
        },
    ],
});
router.start();
