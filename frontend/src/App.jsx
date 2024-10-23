import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './pages/Home';
import { Login } from './pages/Login';
import { Register } from './pages/Register';
import { EmailConfirmedModal } from './pages/EmailConfirmedModal';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ForgotPassword } from './pages/ForgotPassword';
import { ResetPassword } from './pages/ResetPassword';
import { Dashboard } from './admin/Dashboard';
import { Account } from './admin/Account';
import { News } from './admin/News';
import { CVs } from './admin/CVs';
import { PaymentManager } from './admin/PaymentManager';

import AdminLayout from './admin/AdminLayout'; // Adjust the import based on your folder structure

function App() {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />} />
                    <Route path="/emailconfirmedmodal" element={<EmailConfirmedModal />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/forgot-password" element={<ForgotPassword />} />
                    <Route path="/reset-password" element={<ResetPassword />} />

                    {/* Admin Routes */}
                    <Route path="/admin" element={<AdminLayout />}>
                        <Route path="dashboard" element={<Dashboard />} />
                        <Route path="account" element={<Account />} />
                        <Route path="news" element={<News />} />
                        <Route path="cvs" element={<CVs />} />
                        <Route path="paymentmanager" element={<PaymentManager />} />
                    </Route>
                </Routes>
            </Layout>
        </Router>
    );
}

export default App;
