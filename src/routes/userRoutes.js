import { addNewUser} from '../controllers/userController';

const userRoutes = (app) => {
    app.route('/register')
    .post((req, res, next) => {
        if (!req.headers['accept'].includes('application/json', 0)) {
            res.redirect('/');
          } else {
            next()
          }
    }, addNewUser);

    app.route('/user/:token')
    .get()
    .put()
    .delete();
}

export default userRoutes;