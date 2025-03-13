package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PostProjectExample
{
    fun postProject()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val projectPost = ProjectPost(
            name = "My Project",
            key = "project-key-123abc",
        )

        try
        {
            val response = ProjectsApi().postProject(
                projectPost = projectPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ProjectsApi#postProject")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ProjectsApi#postProject")
            e.printStackTrace()
        }
    }
}
