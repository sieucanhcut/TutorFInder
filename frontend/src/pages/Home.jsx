import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../css/styles.css';

export const Home = () => {
    return (
        <div className="container my-5">
            <h3 className="text-center text-success mb-4">Featured Tutors</h3>
            <div className="row justify-content-center card-container">
                <div className="col-md-4">
                    <div className="card border-success mb-4 shadow-sm">
                        <img src="/images/1.png" className="card-img-top" alt="Tutor 1" />
                        <div className="card-body">
                            <h5 className="card-title text-success">Tutor 1 - Mathematics</h5>
                            <p className="card-text">Expert in high school and college-level math.</p>
                            <Link to="#" className="btn btn-outline-success mt-auto">View Profile</Link>
                        </div>
                    </div>
                </div>
                <div className="col-md-4">
                    <div className="card border-success mb-4 shadow-sm">
                        <img src="/images/2.png" className="card-img-top" alt="Tutor 2" />
                        <div className="card-body">
                            <h5 className="card-title text-success">Tutor 2 - Science</h5>
                            <p className="card-text">Expert in high school and college-level science.</p>
                            <Link to="#" className="btn btn-outline-success mt-auto">View Profile</Link>
                        </div>
                    </div>
                </div>
                <div className="col-md-4">
                    <div className="card border-success mb-4 shadow-sm">
                        <img src="/images/3.png" className="card-img-top" alt="Tutor 3" />
                        <div className="card-body">
                            <h5 className="card-title text-success">Tutor 3 - English</h5>
                            <p className="card-text">Expert in high school and college-level English.</p>
                            <Link to="#" className="btn btn-outline-success mt-auto">View Profile</Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};
