const Issue = require('../models').Issue;

module.exports = {
    index: (req, res) => {
        Issue.findAll().then(issues => {

            res.render('issue/index', {'issues': issues})
        });
    },
	
    createGet: (req, res) => {
        res.render('issue/create');
    },
	
    createPost: (req, res) => {
        let arg = req.body.issue;

        Issue.create(arg).then(() => {
            return res.redirect('/');
        })
    },
	
    editGet: (req, res) => {
        let id = req.params.id;
        Issue.findById(id).then(issue => {

            res.render('issue/edit', {'issue': issue});
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let arg = req.body.issue;
        Issue.findById(id).then(issue => {
            issue.updateAttributes(arg).then(() => {
                return res.redirect('/');
            })
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;
        Issue.findById(id).then(issue => {

            res.render('issue/delete', {'issue': issue});

        })
    },
	
    deletePost: (req, res) => {
        let id = req.params.id;
        Issue.findById(id).then(issue => {
            issue.destroy().then(() => {
                return res.redirect('/');
            })
        })
    }
};