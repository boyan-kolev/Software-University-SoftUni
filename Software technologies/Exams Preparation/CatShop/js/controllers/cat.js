const Cat = require('../models').Cat;

module.exports = {
    index: (req, res) => {
        Cat.findAll().then(cats => {

            res.render('cat/index', {'cats': cats})
        });
    },

    createGet: (req, res) => {
        res.render('cat/create');
    },

    createPost: (req, res) => {
        let arg = req.body.cat;

        Cat.create(arg).then(() => {
            return res.redirect('/');
        })
    },

    editGet: (req, res) => {
        let id = req.params.id;
        Cat.findById(id).then(cat => {

            res.render('cat/edit', {'cat': cat});
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let arg = req.body.cat;
        Cat.findById(id).then(cat => {
            cat.updateAttributes(arg).then(() => {
                return res.redirect('/');
            })
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;
        Cat.findById(id).then(cat => {

            res.render('cat/delete', {'cat': cat});

        })
    },

    deletePost: (req, res) => {
        let id = req.params.id;
        Cat.findById(id).then(cat => {
            cat.destroy().then(() => {
                return res.redirect('/');
            })
        })
    }
};
