﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Ypsilon.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace Ypsilon.Entities.Particles
{
    class Trail
    {
        Vector3 m_Offset;
        VertexPositionColorTexture[] m_Vertices;
        private float m_SecondsSinceLastVector = 0;
        private const float c_SecondsBetweenVectors = 0.2f;

        public Trail(Vector3 offset)
        {
            m_Offset = offset;
            m_Vertices = new VertexPositionColorTexture[10];
            for (int i = 0; i < m_Vertices.Length; i++)
            {
                float a = i < 4 ? MathHelper.Lerp(0f, 1f, (i * 0.25f)) : 1;
                m_Vertices[i].Position = m_Offset;
                m_Vertices[i].Color = new Color(.5f * a, .5f * a, 1f * a, a);
            }
        }

        public void Update(double frameSeconds, Vector3 offset)
        {
            for (int i = 0; i < m_Vertices.Length - 1; i++)
            {
                m_Vertices[i].Position -= offset;
            }

            m_SecondsSinceLastVector += (float)frameSeconds;
            if (m_SecondsSinceLastVector >= c_SecondsBetweenVectors)
            {
                m_SecondsSinceLastVector -= c_SecondsBetweenVectors;
                for (int i = 1; i < m_Vertices.Length; i++)
                    m_Vertices[i - 1].Position = m_Vertices[i].Position;
            }
        }

        public void Draw(VectorRenderer renderer, Matrix worldMatrix)
        {
            m_Vertices[m_Vertices.Length - 1].Position = Vector3.Transform(m_Offset, worldMatrix);
            renderer.DrawPolygon(m_Vertices, false);
        }
    }
}