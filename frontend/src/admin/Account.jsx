import React, { useEffect, useState } from 'react';
import axios from 'axios';

export const Account = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [confirmBlockUserId, setConfirmBlockUserId] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");
    const [selectedRole, setSelectedRole] = useState("All"); // State for selected role

    const TUTOR_ROLE_ID = "0E60F4D5-29AA-46F1-8689-B936CF3C2DB6";
    const STUDENT_ROLE_ID = "C6314EB1-0BFF-4E02-9B69-EB004395E59F";

    // Fetch users based on search term and selected role
    const fetchUsers = async () => {
        try {
            let url = `http://localhost:5145/api/admin/users?searchTerm=${searchTerm}`;
            
            // Gửi roleId nếu vai trò được chọn
            if (selectedRole !== "All") {
                const roleId = selectedRole === "Tutor" ? TUTOR_ROLE_ID : STUDENT_ROLE_ID;
                url += `&roleId=${roleId}`;
            }

            const response = await axios.get(url);
            setUsers(response.data);
        } catch (err) {
            setError('Failed to fetch users');
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchUsers(); // Fetch users when component mounts or search term/role changes
    }, [searchTerm, selectedRole]);

    const handleBlockUser = async (userId) => {
        setConfirmBlockUserId(userId);
    };

    const confirmBlock = async () => {
        if (confirmBlockUserId) {
            try {
                await axios.put(`http://localhost:5145/api/admin/users/${confirmBlockUserId}/block`, {
                    roleId: "6425aec4-e6e1-4287-95f2-5ee8862429d4" // Blocked Role ID
                });
                fetchUsers(); // Refresh the users list after blocking
            } catch (err) {
                setError('Failed to block user');
            } finally {
                setConfirmBlockUserId(null);
            }
        }
    };

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const year = date.getFullYear();
        return `${day}/${month}/${year}`;
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div>
            <h2>User Accounts</h2>
            <input
                type="text"
                placeholder="Search users..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <select value={selectedRole} onChange={(e) => setSelectedRole(e.target.value)}>
                <option value="All">All</option>
                <option value="Tutor">Tutor</option>
                <option value="Student">Student</option>
            </select>
            <table className="table table-dark">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Tên</th>
                        <th scope="col">Email</th>
                        <th scope="col">Số điện thoại</th>
                        <th scope="col">Ngày đăng ký</th>
                        <th scope="col">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user, index) => (
                        <tr key={user.userId}>
                            <th scope="row">{index + 1}</th>
                            <td>{user.userName}</td>
                            <td>{user.email}</td>
                            <td>{user.phoneNumber}</td>
                            <td>{formatDate(user.registrationDate)}</td>
                            <td>
                                {user.roleId === "6425aec4-e6e1-4287-95f2-5ee8862429d4" ? (
                                    <span className="btn btn-success" disabled>
                                        Blocked
                                    </span>
                                ) : (
                                    <button
                                        className="btn btn-warning"
                                        onClick={() => handleBlockUser(user.userId)}
                                    >
                                        Block
                                    </button>
                                )}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {/* Confirmation Popup */}
            {confirmBlockUserId && (
                <div className="modal" tabIndex="-1" role="dialog" style={{ display: 'block' }}>
                    <div className="modal-dialog" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">Confirm Block User</h5>
                                <button type="button" className="close" onClick={() => setConfirmBlockUserId(null)}>
                                    <span>&times;</span>
                                </button>
                            </div>
                            <div className="modal-body">
                                <p>Are you sure you want to block this user?</p>
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" onClick={() => setConfirmBlockUserId(null)}>
                                    Cancel
                                </button>
                                <button type="button" className="btn btn-danger" onClick={confirmBlock}>
                                    Block
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};
