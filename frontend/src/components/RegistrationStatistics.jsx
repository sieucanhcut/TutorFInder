import React, { useEffect, useState } from 'react';
import { Line } from 'react-chartjs-2';
import { Chart as ChartJS } from 'chart.js';
import { CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, Legend } from 'chart.js';
import axios from 'axios';

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, Legend);

const RegistrationStatistics = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [period, setPeriod] = useState('month'); // Default to month

    useEffect(() => {   
        const fetchStatistics = async () => {
            try {
                const response = await axios.get(`http://localhost:5145/api/admin/statistics?period=${period}`);
                setData(response.data);
            } catch (err) {
                setError('Failed to fetch statistics');
            } finally {
                setLoading(false);
            }
        };

        fetchStatistics();
    }, [period]);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    // Prepare data for Chart.js
    const labels = data.map(d => new Date(d.date).toLocaleDateString());
    const studentCounts = data.map(d => d.studentCount);
    const tutorCounts = data.map(d => d.tutorCount);

    const chartData = {
        labels: labels,
        datasets: [
            {
                label: 'Students',
                data: studentCounts,
                fill: false,
                backgroundColor: 'rgba(75,192,192,0.4)',
                borderColor: 'rgba(75,192,192,1)',
            },
            {
                label: 'Tutors',
                data: tutorCounts,
                fill: false,
                backgroundColor: 'rgba(255,99,132,0.4)', // Color for Tutors
                borderColor: 'rgba(255,99,132,1)', // Border color for Tutors
            },
        ],
    };

    const chartOptions = {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    stepSize: 1,
                    callback: (value) => Number.isInteger(value) ? value : '',
                },
            },
        },
    };

    return (
        <div style={{ width: '80%', height: '400px', margin: '0 auto' }}>
            <h2>Registration Statistics</h2>
            <select onChange={(e) => setPeriod(e.target.value)} value={period}>
                <option value="day">Daily</option>
                <option value="month">Monthly</option>
                <option value="year">Yearly</option>
            </select>
            <Line data={chartData} options={chartOptions} />
        </div>
    );
};

export default RegistrationStatistics;
