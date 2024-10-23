import React from 'react';
import { useLocation } from 'react-router-dom';
import { ResetPassword } from './ResetPassword';

export const ResetPasswordPage = () => {
    const query = new URLSearchParams(useLocation().search);
    const token = query.get('token');
    const email = query.get('email');

    return (
        <div>
            <h2>Đặt Lại Mật Khẩu</h2>
            <ResetPassword token={token} email={email} />
        </div>
    );
};

export default ResetPasswordPage;
