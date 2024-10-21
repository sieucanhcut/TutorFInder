    import React from 'react';
    import RegistrationStatistics from '../components/RegistrationStatistics'; // Nhập component biểu đồ

    export const Dashboard = () => {
        return (
            <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                <h1>Dashboard</h1>
                {/* Thêm component biểu đồ vào đây */}
                <RegistrationStatistics />
                {/* Các nội dung khác của dashboard */}
            </div>
        );
    };

    export default Dashboard;
